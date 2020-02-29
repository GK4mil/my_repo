<?php
//System powstał na Wydziale Informatyki i Nauk o Żywności PWSIiP w Łomży
error_reporting(0);
require_once('db_connect.php');
try
{
	$key = "klucz";
	$post_key= $sensor = $value= "";

	if ($_SERVER["REQUEST_METHOD"] == "POST"&&isset($_POST['sensor_id'])&&isset($_POST['value'])&&isset($_POST['api_key'])) 
	{
		$post_key = test_input($_POST["api_key"]);

		if($key == $post_key) 
		{
			$pdo=new PDO($MYSQL_STRING, $USERNAME,$PASSWORD);
			$stmt = $pdo -> prepare("INSERT INTO sensors_data (sensor_id, value, date)
        								VALUES (:id, :val, sysdate() )");
			$count = $stmt -> execute(array(':id' => test_input($_POST['sensor_id']), ':val' => test_input($_POST['value'])));
		
			if($count==0)
			{
				throw new Exception();
			}
		}
		else
		{
			http_response_code(403);
		}
	}
	else 
	{
		http_response_code(406);
	}
}
catch(Exception $e)
{
	http_response_code(500);
}

function test_input($data) 
	{
		$data = trim($data);
		$data = stripslashes($data);
		$data = htmlspecialchars($data);
		return $data;
	}
?>	