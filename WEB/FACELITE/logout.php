<?php
session_start();
$_SESSION['logoutsuccess']=True;
header('Location:index.php');
?>