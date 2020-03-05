<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>FaceLite</title>
    <link rel="icon" type="image/png" href="logo.png" />
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto">
    <link rel="stylesheet" href="assets/css/-Login-form-Page-BS4-.css">
    <link rel="stylesheet" href="assets/css/dh-card-image-left-dark.css">
    <link rel="stylesheet" href="assets/css/Different-Styled---Cards.css">
    <link rel="stylesheet" href="assets/css/Different-Styled---Cards.css">
    <link rel="stylesheet" href="assets/css/Footer-Basic.css">
    <link rel="stylesheet" href="assets/css/Navigation-with-Button.css">
    <link rel="stylesheet" href="assets/css/News-Cards.css">
    <link rel="stylesheet" href="assets/css/Pretty-Registration-Form.css">
    <link rel="stylesheet" href="assets/css/styles.css">
    <link rel="stylesheet" href="assets/css/Team-with-rotating-cards.css">
</head>

<body>
    <nav class="navbar navbar-light navbar-expand-md navigation-clean-button" style="background-color:rgb(106,204,235);width:100%;padding:0px;padding-right:8%;padding-left:8%;height:52px;" data-spy="affix" data-offset-top="0">
        <div class="container-fluid"><a class="navbar-brand" href="index.php" style="font-size:26px;"><img src="assets/img/50614311_679752745759793_4359461169161830400_n.png" style="width:40px;height:40px;"></a><button class="navbar-toggler" data-toggle="collapse" data-target="#navcol-1"><span class="sr-only">Toggle navigation</span><span class="navbar-toggler-icon"></span></button>
            <div
                class="collapse navbar-collapse" id="navcol-1">
                <ul class="nav navbar-nav mr-auto"></ul>
                <ul class="nav navbar-nav mr-auto"></ul>
                <ul class="nav navbar-nav">
                    <li class="dropdown"><a class="dropdown-toggle nav-link text-monospace text-capitalize dropdown-toggle" data-toggle="dropdown" aria-expanded="false" href="#" style="font-family:Roboto, sans-serif;">
						<?php
								session_start();
								if(isset($_SESSION['zalogowany']))
									echo $_SESSION['zalogowany'];
								else
									header('Location:index.php');
							?></a>
                        <div class="dropdown-menu" role="menu"><a class="dropdown-item" role="presentation" href="main.php">Twoje posty</a><a class="dropdown-item"
                                    role="presentation" href="logout.php">Wyloguj</a></div>
                    </li>
                </ul>
        </div>
        </div>
    </nav>
    <div style="height:60px;"></div>
    <section>
        <div class="container">
            <?php
			require_once("connect.php");
               $pdo = new PDO('mysql:host='.$host.';dbname='.$db_name.';charset=utf8', $db_user);
	$pdo -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
               $stm = $pdo -> prepare('select * from `friends`, `user` where userid=:idzal
			   and `user`.id=friendid');
		$stm -> bindValue(':idzal', $_SESSION['idzalogowany'], PDO::PARAM_STR);
		$stm ->execute();
		
		
		
		while($row1 = $stm->fetch())
		{
			echo '<div class="photo-card friends" style="background-color:rgba(106,204,235,0.46);height:50px;">
                <div class="d-sm-inline photo-details" style="color:rgb(69,144,218);height:100%;padding-right:35px;padding-left:18px;padding-top:23px;width:100%;">
                    <div style="float:right;margin-top:0px;margin-bottom:-1px;margin-left:0px;margin-right:0px;height:32px;width:0px;">
                        <div class="dropdown" style="color:rgb(69,144,218);"><button class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-expanded="false" type="button" style="background-color:rgba(106,204,235,0.46);color:rgb(0,0,0);padding:9px;margin-top:-26px;margin-bottom:0px;margin-right:0px;margin-left:-45px;padding-top:4px;padding-bottom:4px;">Więcej</button>
                            <div
                                class="dropdown-menu" role="menu" style="padding-top:7px;margin-top:-8px;margin-right:0px;margin-left:-133px;"><a class="dropdown-item" role="presentation" href="friend_deleting.php?id='.$row1['friendid'].'">Usuń ze znajomych</a></div>
                    </div>
                </div>
                <p style="color:rgb(0,0,0);font-weight:bold;font-size:20px;margin-bottom:1px;margin-top:-17px;"><a href="profile.php?id='.$row1['friendid'].'">'.$row1['username'].'</a></p>
                
            </div>
        </div>';
			
		}
               
        
               
        ?>
        </div>
        <div style="height:16px;"></div>
    </section>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/js/add_post_image.js"></script>
</body>

</html>