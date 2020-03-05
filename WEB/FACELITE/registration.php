<?php
require_once("connect.php");
session_start();
if(!(isset($_POST['username'])&&isset($_POST['pass'])&&isset($_POST['mail'])))
{
	header('Location: register.php');
}
elseif(isset($zalogowany))
{
	header('Location: main.php');
}
else
{
	$pdo = new PDO('mysql:host='.$host.';dbname='.$db_name.';charset=utf8', $db_user);
	$pdo -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	$stm = $pdo -> prepare('select count(*) co from `user` where email=:email');
	$stm -> bindValue(':email', htmlentities($_POST['mail'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR);
	$stm ->execute();
	$row1 = $stm->fetch();
	$stm->closeCursor();
	echo $row1['co'];
    if($row1['co']==0)
	{
		$stmt = $pdo -> prepare('INSERT INTO `user` (`username`, `email`, `pass`)	VALUES(
				:us,
				:mail,
				:pass)');	
			
		$stmt -> bindValue(':us', htmlentities($_POST['username'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR); 
		$stmt -> bindValue(':pass', htmlentities($_POST['pass'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR);
		$stmt -> bindValue(':mail',htmlentities($_POST['mail'],ENT_NOQUOTES,"UTF-8") , PDO::PARAM_STR);
		$stmt -> execute(); 
   		
		$_SESSION['success']=True;
		$pdo=NULL;
		header('Location: index.php');
	}
	else
	{
		$_SESSION['err']=True;
		header('Location: register.php');
	}

}
?>