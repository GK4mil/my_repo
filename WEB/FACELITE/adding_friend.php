<?php
require_once("connect.php");
session_start();
if(!isset($_POST['mail'])&&!isset($_SESSION['$zalogowany']))
{
	header('Location: index.php');
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
    if($row1['co']==1)
	{
		$stm = $pdo -> prepare('select id co from `user` where email=:email');
		$stm -> bindValue(':email', htmlentities($_POST['mail'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR);
		$stm ->execute();
		$row1 = $stm->fetch();
		$stm->closeCursor();
		$idfr=$row1['co'];
		
		
		$stm = $pdo -> prepare('select count(*) co from `friends` where friendid=:fr and userid=:usid');
		$stm -> bindValue(':fr', $idfr, PDO::PARAM_STR);
		$stm -> bindValue(':usid', $_SESSION['idzalogowany'], PDO::PARAM_STR);
		$stm ->execute();
		$row1 = $stm->fetch();
		$stm->closeCursor();
		
		if($row1['co']==0)
		{
		
			$stmt = $pdo -> prepare('INSERT INTO `friends` (`userid`, `friendid`)	VALUES(
				:us,
				:fr)');	
			
			$stmt -> bindValue(':us', htmlentities($_SESSION['idzalogowany'],ENT_NOQUOTES,"UTF-8"), PDO::PARAM_STR); 
			$stmt -> bindValue(':fr', $idfr, PDO::PARAM_STR);
			$stmt -> execute(); 
   		
			$_SESSION['friendsuccess']=True;
			$pdo=NULL;
			header('Location: index.php');
		}
		else
		{
			$_SESSION['frienderr']=True;
			header('Location: index.php');
		}
	}
	else
	{
		$_SESSION['frienderr']=True;
		header('Location: index.php');
	}

}
?>