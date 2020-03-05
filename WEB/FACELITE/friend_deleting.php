<?php
require_once("connect.php");
session_start();
if(!isset($_GET['id'])&&!isset($_SESSION['$zalogowany']))
{
	header('Location: index.php');
}
else
{
	$pdo = new PDO('mysql:host='.$host.';dbname='.$db_name.';charset=utf8', $db_user);
	$pdo -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	$stm = $pdo -> prepare('delete from `friends` where userid=:us and friendid=:fr');
	$stm -> bindValue(':us', $_SESSION['idzalogowany'], PDO::PARAM_STR);
	$stm -> bindValue(':fr', htmlentities($_GET['id'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR);
	$stm ->execute();
	header('Location:friends.php');
    

}
?>