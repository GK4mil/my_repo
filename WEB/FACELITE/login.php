<?php
require_once("connect.php");
session_start();
if(!(isset($_POST['mail'])&&isset($_POST['pass'])))
{
	header('Location: index.php');
}
elseif(isset($_SESSION['$zalogowany']))
{
	header('Location: main.php');
}
else
{
	$pdo = new PDO('mysql:host='.$host.';dbname='.$db_name.';charset=utf8', $db_user);
	$pdo -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	$stm = $pdo -> prepare('select count(*) co from `user` where email=:email and pass=:pass');
	$stm -> bindValue(':email', htmlentities($_POST['mail'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR);
	$stm -> bindValue(':pass', htmlentities($_POST['pass'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR);
	$stm ->execute();
	$row1 = $stm->fetch();
	$stm->closeCursor();
    if($row1['co']==1)
	{
		
		$stm = $pdo -> prepare('select *  from `user` where email=:email and pass=:pass');
		$stm -> bindValue(':email', htmlentities($_POST['mail'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR);
		$stm -> bindValue(':pass', htmlentities($_POST['pass'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR);
		$stm ->execute();
		$row = $stm->fetch();
		$_SESSION['zalogowany']=$row['username'];
		$_SESSION['idzalogowany']=$row['id'];
		header('Location: main.php');
	}
	else
	{
		$_SESSION['logerr']=True;
		header('Location: index.php');
	}

}
?>