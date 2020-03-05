<?php
require_once("connect.php");
session_start();
if(!isset($_POST['content'])&&!isset($_SESSION['$zalogowany']))
{
	header('Location: index.php');
}
else
{
	$pdo = new PDO('mysql:host='.$host.';dbname='.$db_name.';charset=utf8', $db_user);
	$pdo -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	$stm = $pdo -> prepare('INSERT INTO `post` (`userid`, `content`,`data`)	VALUES(
				:us,
				:con,:d)');	
			
		$stm -> bindValue(':us', $_SESSION['idzalogowany'], PDO::PARAM_STR); 
		$stm -> bindValue(':con', htmlentities($_POST['content'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR);
		$stm -> bindValue(':d', date('l jS F Y h:i:s A'), PDO::PARAM_STR);
		$stm -> execute(); 
	header('Location: main.php');

}
?>