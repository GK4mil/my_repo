<!--System powstał na Wydziale Informatyki i Nauk o Żywności PWSIiP w Łomży-->
<?php
require_once('dsmlibrary.php');
error_reporting(0);
header('refresh: 60;');
$dsm=new dsmlibrary();
?>
<!DOCTYPE html>
<html lang="pl-PL">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>DSM - Domowa Stacja Meteorologiczna - Home</title> 
    <link rel="shortcut icon" type="image/png" href="img/brand.png"/>
    <link rel="stylesheet" type="text/css" href="css/loader.css"/>
    <link rel="stylesheet" type="text/css" href="css/index.css"/>
  	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
  	<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
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
        			<a class="nav-link" href="ext_hum.php">&#8226; Wilgotność powietrza</a>
      			</li>
      			<li class="nav-item">
        			<a class="nav-link" href="pressure.php">&#8226; Ciśnienie atmosferyczne</a>
      			</li>
      			<li class="nav-item">
        			<a class="nav-link" href="ext_ins.php">&#8226; Nasłonecznienie</a>
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
   	<div class="container">
   		<div class="row">
   			<div class="col">
   				<h3 class="font-italic">
   					<strong >
   						Najnowsze odczyty
					</strong>
				</h3>
   			</div>
		</div>
   		<div class="row">
   			<div class="col">
				<small class="font-italic"> 
  					Czas ostatniego odczytu danych: 
  						<?php 
							$dsm->check_last_registration();
						?>
				</small>
			</div>	
	  	</div>  	
		<div class="row"> 
  			<div class="col-sm-6">
  				<div class="row">
  					<div class="col">
  						<h3 class="text-primary font-weight-bolder"> Zewnątrz </h3>	
  					</div>		
				</div>
  					<div class="card mb-3">
  						<div class="row no-gutters">
    						<div class="col-md-4">
      							<img type="image/png" src="img/term.png" class="card-img">
    						</div>
    						<div class="col-md-8">
      							<div class="card-body">
		  							<h3 class="card-title"> 
										<strong>
											Temperatura powietrza
										</strong>
       								</h3>
        							<hr>
        							<h2 class="card-text">
        								<strong><?php 
											$dsm->get_data(1);
											echo ' &#8451;';
											$dsm->trend(1);	
											?>
											</strong>
									</h2>
        							<h6 class="card-text">Minimum dobowe:<br>
        							<strong> <?php 
										$dsm->minimum(1);
										echo ' &#8451;';?></strong>
									</h6>
									<h6 class="card-text">Maksimum dobowe:
										<br>
										<strong> <?php 
											$dsm->maximum(1);
											echo ' &#8451;';?></strong>
									</h6>
      							</div>
   							</div>
  						</div>
					</div>		
   					<div class="card mb-3">
  						<div class="row no-gutters">
    						<div class="col-md-4">
      							<img type="image/png" src="img/hum.png" class="card-img">
    						</div>
   				 			<div class="col-md-8">
      							<div class="card-body">
		  							<h3 class="card-title"> 
		  								<strong>
		  									Wilgotność powietrza
		  								</strong>
		  							</h3>
        							<hr>
        							<h2 class="card-text">
        								<strong><?php 
											$dsm->get_data(3);
											echo ' %';
											$dsm->trend(3);	?>
										</strong>
									</h2>
        							<h6 class="card-text">Minimum dobowe:<br>
        								<strong> 
        									<?php 
												$dsm->minimum(3);
												echo ' %';?>
										</strong>
									</h6>
									<h6 class="card-text">Maksimum dobowe:<br>
										<strong> 
											<?php 
												$dsm->maximum(3);
												echo ' %';?>
										</strong>
									</h6>
      							</div>
    						</div>
  						</div>
					</div>
   					<div class="card mb-3">
  						<div class="row no-gutters">
    						<div class="col-md-4">
      							<img type="image/png" src="img/pressure.png" class="card-img">
    						</div>
    						<div class="col-md-8">
      							<div class="card-body">
		  							<h3 class="card-title"> 
		  								<strong>
		  									Ciśnienie atmosferyczne
		  								</strong>
		  							</h3>
        							<hr>
        							<h2 class="card-text">
        								<strong>
        									<?php 
												$dsm->get_data(5);
												echo ' hPa';
												$dsm->trend(5);	?>
										</strong>
									</h2>
        							<h6 class="card-text">Minimum dobowe:<br>
        								<strong> 
        									<?php 
												$dsm->minimum(5);
												echo ' hPa';?>
										</strong>
									</h6>
									<h6 class="card-text">Maksimum dobowe:<br>
										<strong> 
											<?php 
												$dsm->maximum(5);
												echo ' hPa';?>
										</strong>
									</h6>
     							</div>
    						</div>
 						</div>
					</div>	
   					<div class="card mb-3">
  						<div class="row no-gutters">
    						<div class="col-md-4">
      							<img type="image/png" src="img/ins.png" class="card-img">
    						</div>
							<div class="col-md-8">
								<div class="card-body">
									<h3 class="card-title"> 
										<strong>
											Nasłonecznienie
											<br>
											(0-10)
										</strong>
									</h3>
									<hr>
									<h2 class="card-text">
										<strong>
											<?php 
												$dsm->get_data(6);
												$dsm->trend(6);	?>
										</strong>
									</h2>
									<h6 class="card-text">Minimum dobowe:<br>
										<strong> 
											<?php 
												$dsm->minimum(6);?>
										</strong>
									</h6>
									<h6 class="card-text">Maksimum dobowe:<br>
										<strong> 
											<?php 
												$dsm->maximum(6);?>
										</strong>
									</h6>
								</div>
							</div>
  						</div>
					</div>
				</div>	
				<div class="col-sm-6">
					<div class="row">
						<div class="col">
							<h3 class="text-success font-weight-bolder"> Wewnątrz </h3>
						</div>
					</div>
  						<div class="card mb-3">
  							<div class="row no-gutters">
    							<div class="col-md-4">
      								<img type="image/png" src="img/term.png" class="card-img">
    							</div>
    							<div class="col-md-8">
      								<div class="card-body">
		  								<h3 class="card-title"> 
		  									<strong>
		  										Temperatura powietrza
		  									</strong>
		  								</h3>
        								<hr>
        								<h2 class="card-text">
											<strong>
												<?php 
													$dsm->get_data(2);
													echo ' &#8451;';
													$dsm->trend(2);	?>
											</strong>
										</h2>
        								<h6 class="card-text">Minimum dobowe:<br>
											<strong> 
												<?php 
													$dsm->minimum(2);
													echo ' &#8451;';?>
											</strong>
										</h6>
										<h6 class="card-text">Maksimum dobowe:<br>
											<strong> 
												<?php 
													$dsm->maximum(2);
													echo ' &#8451;';?>
											</strong>
										</h6>
      								</div>
    							</div>
  							</div>
						</div>
						<div class="card mb-3">
							<div class="row no-gutters">
								<div class="col-md-4">
									<img type="image/png" src="img/hum.png" class="card-img">
								</div>
								<div class="col-md-8">
									<div class="card-body">
										<h3 class="card-title"> 
											<strong>
												Wilgotność powietrza
											</strong>
										</h3>
										<hr>
										<h2 class="card-text">
											<strong>
												<?php 
													$dsm->get_data(4);
													echo ' %';
													$dsm->trend(4);	
												?>
											</strong>
										</h2>
										<h6 class="card-text">Minimum dobowe:<br>
											<strong> 
												<?php 
													$dsm->minimum(4);
													echo ' %';?>
											</strong>
										</h6>
										<h6 class="card-text">Maksimum dobowe:<br>
											<strong> 
												<?php 
													$dsm->maximum(4);
													echo ' %';?>
											</strong>
										</h6>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
		
		<div class="row">
   			<div class="col-12">
   				<h3 class="font-italic" style="text-align: center;">
   					<strong >
   						Wykresy dobowe
					</strong>
				</h3>
   			</div>
		</div>	
		<div class="row">
			<div class="col-12">
				<div class="row chart" id="chart_ext_temp"></div>
				<div class="row chart" id="chart_int_temp"></div>
				<div class="row chart" id="chart_ext_hum"></div>
				<div class="row chart" id="chart_int_hum"></div>
				<div class="row chart" id="chart_pressure"></div>
				<div class="row chart" id="chart_ext_ins"></div>
			</div>
		</div>
	</div>

	<script src="https://code.jquery.com/jquery-3.4.1.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
	<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
	<script>
  		google.charts.load('current', {packages: ['corechart', 'line']});
		google.charts.setOnLoadCallback(drawBackgroundColor_ext_temp);

		function drawBackgroundColor_ext_temp() 
		{
			  var data = new google.visualization.DataTable();
			  data.addColumn('datetime', 'X');
			  data.addColumn('number', 'Wartość');

			  data.addRows([<?php $dsm->get_data_to_chart(1);?>]);

			  var options = {
				hAxis: {
				  title: 'Godzina pomiaru'
				},
				curveType: 'function',
				title:'Temperatura powietrza zewnętrzna',
				legend: {position: 'none'},
				vAxis: {
				  title: 'Temperatura w °C'
				},
				backgroundColor: '#ffffff'
		  };

		  var chart_ext_temp = new google.visualization.LineChart(document.getElementById('chart_ext_temp'));
		  chart_ext_temp.draw(data, options);
		}
		 
		 
		 
		 
		 
		 
		google.charts.load('current', {packages: ['corechart', 'line']});
		google.charts.setOnLoadCallback(drawBackgroundColor_int_temp);

		function drawBackgroundColor_int_temp() 
		{
			  var data = new google.visualization.DataTable();
			  data.addColumn('datetime', 'X');
			  data.addColumn('number', 'Wartość');

			  data.addRows([<?php $dsm->get_data_to_chart(2);?>]);

			  var options = {
				hAxis: {
				  title: 'Godzina pomiaru'
				},
				curveType: 'function',
				title:'Temperatura powietrza wewnętrzna',
				legend: {position: 'none'},
				vAxis: {
				  title: 'Temperatura w °C'
				},
				backgroundColor: '#ffffff'
		  };

		  var chart_int_temp = new google.visualization.LineChart(document.getElementById('chart_int_temp'));
		  chart_int_temp.draw(data, options);
		}
		 
		 
		 
		 
		google.charts.load('current', {packages: ['corechart', 'line']});
		google.charts.setOnLoadCallback(drawBackgroundColor_ext_hum);

		function drawBackgroundColor_ext_hum() 
		{
			  var data = new google.visualization.DataTable();
			  data.addColumn('datetime', 'X');
			  data.addColumn('number', 'Wartość');

			  data.addRows([<?php $dsm->get_data_to_chart(3);?>]);

			  var options = {
				hAxis: {
				  title: 'Godzina pomiaru'
				},
				curveType: 'function',
				title:'Wilgotność powietrza zewnętrzna',
				legend: {position: 'none'},
				vAxis: {
				  title: 'Wilgotność w %'
				},
				backgroundColor: '#ffffff'
		  };

		  var chart_ext_hum = new google.visualization.LineChart(document.getElementById('chart_ext_hum'));
		  chart_ext_hum.draw(data, options);
		}
		 
		 
		 
		google.charts.load('current', {packages: ['corechart', 'line']});
		google.charts.setOnLoadCallback(drawBackgroundColor_int_hum);

		function drawBackgroundColor_int_hum() 
		{
			  var data = new google.visualization.DataTable();
			  data.addColumn('datetime', 'X');
			  data.addColumn('number', 'Wartość');

			  data.addRows([<?php $dsm->get_data_to_chart(4);?>]);

			  var options = {
				hAxis: {
				  title: 'Godzina pomiaru'
				},
				curveType: 'function',
				title:'Wilgotność powietrza wewnętrzna',
				legend: {position: 'none'},
				vAxis: {
				  title: 'Wilgotność w %'
				},
				backgroundColor: '#ffffff'
		  };

		  var chart_int_hum = new google.visualization.LineChart(document.getElementById('chart_int_hum'));
		  chart_int_hum.draw(data, options);
		}
		 
		 
		google.charts.load('current', {packages: ['corechart', 'line']});
		google.charts.setOnLoadCallback(drawBackgroundColor_pressure);

		function drawBackgroundColor_pressure() 
		{
			  var data = new google.visualization.DataTable();
			  data.addColumn('datetime', 'X');
			  data.addColumn('number', 'Wartość');

			  data.addRows([<?php $dsm->get_data_to_chart(5);?>]);

			  var options = {
				hAxis: {
				  title: 'Godzina pomiaru'
				},
				curveType: 'function',
				title:'Ciśnienie atomosferyczne',
				legend: {position: 'none'},
				vAxis: {
				  title: 'Ciśnienie w hPa'
				},
				backgroundColor: '#ffffff'
		  };

		  var chart_pressure = new google.visualization.LineChart(document.getElementById('chart_pressure'));
		  chart_pressure.draw(data, options);
		}
		 
		 
		 
		google.charts.load('current', {packages: ['corechart', 'line']});
		google.charts.setOnLoadCallback(drawBackgroundColor_ext_ins);

		function drawBackgroundColor_ext_ins() 
		{
			  var data = new google.visualization.DataTable();
			  data.addColumn('datetime', 'X');
			  data.addColumn('number', 'Wartość');

			  data.addRows([<?php $dsm->get_data_to_chart(6);?>]);

			  var options = {
				hAxis: {
				  title: 'Godzina pomiaru'
				
				},
				curveType: 'function',
				title:'Nasłonecznienie w skali (0-10)',
				legend: {position: 'none'},
				vAxis: {
				  title: 'Nasłonecznienie',
					viewWindowMode:'explicit',
    				viewWindow: {
        			max:10,
        			min:0
					}
				},
				backgroundColor: '#ffffff'
		  };

		  var chart_ext_ins = new google.visualization.LineChart(document.getElementById('chart_ext_ins'));
		  chart_ext_ins.draw(data, options);
		}
		
		$(window).resize(function(){
			drawBackgroundColor_ext_temp();
			drawBackgroundColor_int_temp();
			drawBackgroundColor_ext_hum();
			drawBackgroundColor_int_hum();
			drawBackgroundColor_pressure();
			drawBackgroundColor_ext_ins();
		});
  	</script>
  	<script type="text/javascript" src="js/script.js"></script>
  </body>
</html>
