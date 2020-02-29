<?php
//System powstał na Wydziale Informatyki i Nauk o Żywności PWSIiP w Łomży
class dsmlibrary
{
	private $pdo=null;
	
	public function __construct()
   	{
		try
		{
			error_reporting(0);
			require('db_connect.php');
			$this->pdo=new PDO($MYSQL_STRING, $USERNAME,$PASSWORD);
		}
		catch(Exception $e)
		{
			header('Location: error.php');
		}
   	} 
	
	function check_status()
	{
		$stmt = $this->pdo->query('SELECT count(*) as c FROM sensors_data');
    	$row=$stmt->fetch();
		$stmt->closeCursor();
		
		if($row['c']==0)
		{
			echo ' offline <img id="nav_img" type="image/png" src="img/cross.png">';
			return;
		}
		
    	$stmt = $this->pdo->query('SELECT date FROM sensors_data order by date desc');
    	$row=$stmt->fetch();
		$stmt->closeCursor();
		
		$datatime=new DateTime($row['date']);
		
		$stmt = $this->pdo->query('SELECT sysdate() as date FROM dual');
		$row=$stmt->fetch();
		$stmt->closeCursor();
		
		$sysdate=new DateTime($row['date']);
		$datatime->modify('+6 minutes');
		
		if($datatime>=$sysdate)
		{
			echo ' online <img id="nav_img" type="image/png" src="img/check.png">';
		}
		else
		{
			echo ' offline <img id="nav_img" type="image/png" src="img/cross.png">';
		}
	}

	function check_last_registration()
	{
		$stmt = $this->pdo->query('SELECT count(*) as c FROM sensors_data');
    	$row=$stmt->fetch();
		$stmt->closeCursor();
		
		if($row['c']==0)
		{
			echo "-";
			return;
		}
		
		$stmt = $this->pdo->query('SELECT date FROM sensors_data order by date desc');
		$row=$stmt->fetch();
		$stmt->closeCursor();
		echo $row['date'];
	}

	function get_data($id)
	{
		$stmt = $this->pdo->query('SELECT count(*) as c FROM sensors_data');
    	$row=$stmt->fetch();
		$stmt->closeCursor();
		
		if($row['c']==0)
		{
			echo "-";
			return;
		}
		
		$stmt = $this->pdo->prepare('SELECT value FROM sensors_data where sensor_id=:param1 order by date desc');
		$stmt->execute(array(':param1' => $id));
		$row=$stmt->fetch();
		$stmt->closeCursor();
		if($id==5)
			echo $row['value'];
		else
			echo round($row['value']);
	}

	function generate_table($id, $ch, $date)
	{
		$date=$this->test_input($date);
		
		$stmt = $this->pdo->prepare("SELECT count(*) as c FROM sensors_data where sensor_id=:param1 and date like concat('%',:param2,'%')");
		$stmt->execute(array(':param1' => $id,':param2' => $date));
		$row=$stmt->fetch();
		$stmt->closeCursor();
		
		
		if(($count=$row['c'])!=0)
		{
			$stmt = $this->pdo->prepare("SELECT * FROM sensors_data where sensor_id=:param1 and date like concat('%',:param2,'%') order by date desc");
			$stmt->execute(array(':param1' => $id, ':param2' => $date));
			echo '<table class="table table-hover  thead-dark">
					<thead class="thead-dark">
		  			<tr> <th>L.P.</th> <th>Wartość odczytu</th> <th>Data i godzina odczytu</th>
		  			</tr></thead> <tbody>';
			while($row = $stmt->fetch())
			{
				if($id==5)
				{
					echo '<tr>
							<td>'.$count--.'</td>
							<td>'.$row['Value']." ".$ch.'</td>
							<td>'.$row['Date'].'</td></tr>';
				}
				else
				{
					echo '<tr>
						<td>'.$count--.'</td>
						<td>'.round($row['Value'])." ".$ch.'</td>
						<td>'.$row['Date'].'</td></tr>';
				}
			}
			
			$stmt->closeCursor();
			echo '</tbody> </table>';
		}
		else
		{
			echo '<h5 class="text-danger"><strong>Brak danych do wyświetlenia<strong></h5>';
		}
   
	}
	
	function get_start_date($id)
	{
		$stmt = $this->pdo->prepare('SELECT count(*) as c FROM sensors_data where sensor_id=:param1');
		$stmt->execute(array(':param1' => $id));
    	$row=$stmt->fetch();
		$stmt->closeCursor();
		
		if($row['c']==0)
		{
			return date("Y-m-d");
			
		}
		
		$stmt = $this->pdo->prepare('SELECT date(Date) as start_date FROM sensors_data where sensor_id=:param1 order by date asc');
		$stmt->execute(array(':param1' => $id));
		$row=$stmt->fetch();
		$stmt->closeCursor();
		return $row['start_date'];
	}
	
	function get_end_date($id)
	{
		$stmt = $this->pdo->prepare('SELECT count(*) as c FROM sensors_data where sensor_id=:param1');
		$stmt->execute(array(':param1' => $id));
    	$row=$stmt->fetch();
		$stmt->closeCursor();
		
		if($row['c']==0)
		{
			return date("Y-m-d");
		}
		
		$stmt = $this->pdo->prepare('SELECT date(Date) as end_date FROM sensors_data where sensor_id=:param order by date desc');
		$stmt->execute([':param' => $id]);
		$row=$stmt->fetch();
		$stmt->closeCursor();
		return $row['end_date'];
	}
	
	function test_input($data) 
	{
		$data = trim($data);
		$data = stripslashes($data);
		$data = htmlspecialchars($data);
		return $data;
	}
	
	function validateDate($date, $format = 'Y-m-d')
	{
		$d = DateTime::createFromFormat($format, $date);
		return $d && $d->format($format) === $date;
	}
	
	function trend($id)
	{
		$stmt = $this->pdo->prepare("SELECT count(*) as c FROM sensors_data where sensor_id=:param1");
		$stmt->execute(array(':param1' => $id));
		$row=$stmt->fetch();
		$stmt->closeCursor();
		
		
		if(($count=$row['c'])>=5)
		{
			$stmt = $this->pdo->prepare("SELECT value FROM sensors_data where sensor_id=:param1 order by date desc");
			$stmt->execute([':param1' => $id]);
			$row=$stmt->fetch();
			$current_value=$row['value'];
			$avg=0;
			
			for ($i = 0; $i < 4; $i++) 
			{
				$row = $stmt->fetch();
				$avg+=(float)$row['value'];
			}
			
			$stmt->closeCursor();
			$avg/=4;
			if($avg<$current_value)
				echo ' &#8599;';
			elseif($avg==$current_value)
				echo ' &#8594;';
			else
				echo ' &#8600;';
		}
		
		
	}
	
	function maximum($id)
	{
		$stmt = $this->pdo->prepare("SELECT count(*) as c FROM sensors_data where sensor_id=:param1 and date like concat('%',(select max(date(date)) from sensors_data where sensor_id=:param1),'%')");
		$stmt->execute(array(':param1' => $id));
		$row=$stmt->fetch();
		$stmt->closeCursor();
		
		if(($row['c'])>=1)
		{
			$stmt = $this->pdo->prepare("SELECT max(value) as max FROM sensors_data where sensor_id=:param1 and date like concat('%',(select max(date(date)) from sensors_data where sensor_id=:param1),'%')");
			$stmt->execute(array(':param1' => $id));
			$row=$stmt->fetch();
			$stmt->closeCursor();
			if($id==5)
				echo $row['max'];
			else
				echo round($row['max']);
		}
		else
			echo '-';
	}
	
	function minimum($id)
	{
		$stmt = $this->pdo->prepare("SELECT count(*) as c FROM sensors_data where sensor_id=:param1 and date like concat('%',(select max(date(date)) from sensors_data where sensor_id=:param1),'%')");
		$stmt->execute(array(':param1' => $id));
		$row=$stmt->fetch();
		$stmt->closeCursor();
		
		if(($row['c'])>=1)
		{
			$stmt = $this->pdo->prepare("SELECT min(value) as min FROM sensors_data where sensor_id=:param1 and date like concat('%',(select max(date(date)) from sensors_data where sensor_id=:param1),'%')");
			$stmt->execute(array(':param1' => $id));
			$row=$stmt->fetch();
			$stmt->closeCursor();
			if($id==5)
				echo $row['min'];
			else
				echo round($row['min']);
		}
		else
			echo '-';
	}
	
	function get_data_to_chart($id)
	{		
		$stmt = $this->pdo->prepare("SELECT count(*) as c FROM sensors_data where sensor_id=:param1 and date like concat('%',(select max(date(date)) from sensors_data where sensor_id=:param1),'%')");
		$stmt->execute(array(':param1' => $id));
		$row=$stmt->fetch();
		$stmt->closeCursor();
			
		if(($iter=$row['c'])!=0)
		{
			$stmt = $this->pdo->prepare("SELECT year(date(date)) as y, month(date(date))-1 as m, day(date(date)) as d, hour(time(date)) as h, minute(time(date)) as i, second(time(date)) as s, value FROM sensors_data where sensor_id=:param1 and date like concat('%',(select max(date(date)) from sensors_data where sensor_id=:param1),'%')");
			$stmt->execute(array(':param1' => $id));
			
			
			while(($row = $stmt->fetch())&&$iter>=1)
			{
				echo '[new Date('.$row['y'].','.$row['m'].','.$row['d'].','.$row['h'].','.$row['i'].','.$row['s'].'),'.$row['value'].']';
				if($iter--!=1)
					echo ',';
			}
			
			$stmt->closeCursor();
			
		}
	}
	
	function get_data_to_chart_with_date($id, $date)
	{
		$date=$this->test_input($date);
		$stmt = $this->pdo->prepare("SELECT count(*) as c FROM sensors_data where sensor_id=:param1 and date like concat('%',:param2,'%')");
		$stmt->execute(array(':param1' => $id,':param2' => $date));
		$row=$stmt->fetch();
		$stmt->closeCursor();
			
		if(($iter=$row['c'])!=0)
		{
			$stmt = $this->pdo->prepare("SELECT year(date(date)) as y, month(date(date))-1 as m, day(date(date)) as d, hour(time(date)) as h, minute(time(date)) as i, second(time(date)) as s, value  FROM sensors_data where sensor_id=:param1 and date like concat('%',:param2,'%')");
			$stmt->execute(array(':param1' => $id,':param2' => $date));
			
			
			while(($row = $stmt->fetch())&&$iter>=1)
			{
				echo '[new Date('.$row['y'].','.$row['m'].','.$row['d'].','.$row['h'].','.$row['i'].','.$row['s'].'),'.$row['value'].']';
				if($iter--!=1)
					echo ',';
			}
			
			$stmt->closeCursor();
			
		}
	}
}

?>