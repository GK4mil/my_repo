<!--System powstał na Wydziale Informatyki i Nauk o Żywności PWSIiP w Łomży-->
<?php
require_once('dsmlibrary.php');
$dsm=new dsmlibrary();
error_reporting(0);
$sensor_id=3;
$mark="%";
?>
<!DOCTYPE html>
<html lang="pl-PL">
   <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>DSM - Wilgotność powietrza zewnętrzna</title> 
    <link rel="shortcut icon" type="image/png" href="img/brand.png"/>
    <link rel="stylesheet" type="text/css" href="css/loader.css"/>
  	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
  	<link rel="stylesheet" type="text/css" href="css/other.css"/>	
  	<script src="https://www.gstatic.com/charts/loader.js"></script>
  </head>
  <body>
  	<div id="loader-wrapper">
		<div class="load">
			<hr/><hr/><hr/><hr/>
		</div>
		<div id="info"> System powstał na </div>
		<div id="info"> Wydziale Informatyki i Nauk o Żywności </div>
		<div id="info"> PWSIiP w Łomży</div>
	</div>
  	<nav class="navbar  bg-dark navbar-dark">
		<a class="navbar-brand" id="brand" href="index.php">
			<img id="nav_img" src="img/brand.png" alt="DSM - Strona główna"> DSM
		</a>
		<span class="navbar-text font-italic" id="dev-status" > Status urządzenia:
			<?php 
				$dsm->check_status();
			?>
		</span>

	  	<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
			<span class="navbar-toggler-icon"></span>
	  	</button>

	  	<div class="collapse navbar-collapse" id="collapsibleNavbar">
			<ul class="navbar-nav font-italic">
				<hr>
				<li class="nav-item">
					<span class="text-muted font-weight-bold font-italic">Wykazy zebranych pomiarów </span>
				</li>
				<hr>
				<li class="nav-item">
					<span class="text-primary font-weight-bold font-italic">Warunki zewnętrzne </span>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="ext_temp.php">&#8226; Temperatura powietrza</a>
				</li>
				<li class="nav-item">
					<a class="nav-link active" href="ext_hum.php">&#8226; Wilgotność powietrza</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="pressure.php">&#8226; Ciśnienie atmosferyczne</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="ext_ins.php">&#8226; Nasłonecznienie</a>
				</li>
				<hr>
				<li class="nav-item">
					<span class="text-success font-weight-bold">Warunki wewnętrzne </span>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="int_temp.php">&#8226; Temperatura powietrza</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="int_hum.php">&#8226; Wilgotność powietrza</a>
				</li>
			</ul>
	  	</div>
	</nav> 
   
   	<div class="container">
   		
   		<div class="row">
   			<div class="col-12">
   				<h3><strong>Wilgotność powietrza zewętrzna</strong></h3>
   				<h5> Dane historyczne</h5>
   			</div>
   		</div>
   		
   		<div class="row">
	   		<div class="col-12">
		   		<form action="ext_hum.php" method="get">
		   			<p>Wybierz datę pomiarów:</p> 
					<input required type="date" name="date" id="start" 
						value="<?php 
						   	if(isset($_GET['date']))
							{
								if($dsm->validateDate($_GET['date']))
									echo $_GET['date'];
								else
									echo $dsm->get_end_date($sensor_id);
							}
							else
							{	
								echo $dsm->get_end_date($sensor_id);
							}	
								?>"
						min="<?php 
							echo $dsm->get_start_date($sensor_id);
							?>" 
						max="<?php 
							echo $dsm->get_end_date($sensor_id);
							?>">
					<input type="submit" value="Wyświetl pomiary">
				</form>	
		  	</div>
   		</div>
   		
   		<div class="row">
   			<div class="col-12">
   				<h3>
   					Wykres dobowy
				</h3>
   			</div>
		</div>
			
		<div class="row">
			<div class="col-12">
				<div id="chart"></div>
			</div>
		</div>
		
		<div class="row">
   			<div class="col-12">
   				<h3>
   					Tabela pomiarów dobowych
				</h3>
   			</div>
		</div>
		
		<div class="row">
			<div class="col-12">						
   				<?php
	   				if(isset($_GET['date']))
					{
						if($dsm->validateDate($_GET['date']))
							$dsm->generate_table($sensor_id,$mark,$_GET['date']);
						else
							$dsm->generate_table($sensor_id,$mark,$dsm->get_end_date($sensor_id));
					}
					else
						$dsm->generate_table($sensor_id,$mark,$dsm->get_end_date($sensor_id));
						  
				?>
			</div>
	   	</div>
	   	
   	</div>
   
 	<script src="https://code.jquery.com/jquery-3.4.1.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
	<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
	
  	<script>
		google.charts.load('current', {packages: ['corechart', 'line']});
		google.charts.setOnLoadCallback(drawBackgroundColor);

		function drawBackgroundColor() 
		{
			var data = new google.visualization.DataTable();
			data.addColumn('datetime', 'X');
			data.addColumn('number', 'Wartość');

			data.addRows([<?php 
							if(isset($_GET['date']))
							{
								if($dsm->validateDate($_GET['date']))
									$dsm->get_data_to_chart_with_date($sensor_id,$_GET['date']);
								else
									$dsm->get_data_to_chart_with_date($sensor_id,$dsm->get_end_date($sensor_id));
							}
							else
								$dsm->get_data_to_chart_with_date($sensor_id,$dsm->get_end_date($sensor_id));
							?>]);

			var options = {
				hAxis: {title: 'Godzina pomiaru'},
				curveType: 'function',
				legend: {position: 'none'},
				vAxis: {title: 'Wilgotność w %'},
				backgroundColor: '#ffffff'
		  	};

		  	var chart = new google.visualization.LineChart(document.getElementById('chart'));
		  	chart.draw(data, options);
		}
		
		$(window).resize(function(){
			drawBackgroundColor();
		});
	</script>
	<script type="text/javascript" src="js/script.js"></script>
  </body>
</html>