<!--System powstał na Wydziale Informatyki i Nauk o Żywności PWSIiP w Łomży-->
<!DOCTYPE html>
<?php
require_once('dsmlibrary.php');
header('refresh:10;url=index.php');
error_reporting(0);
?>
<html lang="pl-PL">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>DSM - Domowa Stacja Meteorologiczna - Home</title> 
    <link rel="shortcut icon" type="image/png" href="img/brand.png"/>
    <link rel="stylesheet" type="text/css" href="css/loader.css"/> 
  	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">	
  	<link rel="stylesheet" type="text/css" href="css/other.css"/>
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
			<span class="navbar-text font-italic" id="dev-status" > Status urządzenia: offline <img id="nav_img" type="image/png" src="img/cross.png"></span>
			
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
					<a class="nav-link" href="ext_hum.php">&#8226; Wilgotność powietrza</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="pressure.php">&#8226; Ciśnienie atmosferyczne</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="insolation.php">&#8226; Nasłonecznienie</a>
				</li>
				<hr>
				<li class="nav-item">
					<span class="text-success font-weight-bold ">Warunki wewnętrzne </span>
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
 
   	<div class="container" style="border: none;">
  		<div class="row">
  			<div class="col-12">
  				<h3> Serwis niedostępny</h3>
  			</div>
  		</div>
	</div>
   
 	<script src="https://code.jquery.com/jquery-3.4.1.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
	<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
	<script type="text/javascript" src="js/script.js"></script>
  </body>
</html>