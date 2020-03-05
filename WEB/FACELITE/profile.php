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
    <div>
        <nav class="navbar navbar-light navbar-expand-md navigation-clean-button" style="background-color:rgb(106,204,235);width:100%;padding:0px;padding-right:8%;padding-left:8%;height:52px;" data-spy="affix" data-offset-top="0">
            <div class="container-fluid"><a class="navbar-brand" href="index.php" style="font-size:26px;"><img src="assets/img/50614311_679752745759793_4359461169161830400_n.png" style="width:40px;height:40px;"></a><button class="navbar-toggler" data-toggle="collapse" data-target="#navcol-1"><span class="sr-only">Toggle navigation</span><span class="navbar-toggler-icon"></span></button>
                <div
                    class="collapse navbar-collapse" id="navcol-1">
                    <ul class="nav navbar-nav mr-auto">
                        <li class="nav-item" role="presentation"><a class="nav-link" href="#add_post_modal" style="color:rgb(0,0,0);font-weight:normal;font-family:Roboto, sans-serif;" data-toggle="modal" data-target="#add_post_modal">Dodaj post</a></li>
                        <li class="nav-item" role="presentation"><a class="nav-link" href="friends.php" style="color:rgb(0,0,0);font-weight:normal;font-family:Roboto, sans-serif;">Znajomi</a></li>
                    </ul>
                    <ul class="nav navbar-nav mr-auto"></ul>
                    <ul class="nav navbar-nav">
                        <li class="dropdown"><a class="dropdown-toggle nav-link text-monospace text-capitalize dropdown-toggle" data-toggle="dropdown" aria-expanded="false" href="#" style="font-family:Roboto, sans-serif;">
							<?php
								session_start();
								if(isset($_SESSION['zalogowany']))
									echo $_SESSION['zalogowany'];
								else
									header('Location:index.php');
							?>
                           
                           
                           </a>
                            <div class="dropdown-menu" role="menu"><a class="dropdown-item" role="presentation" href="main.php">Twoje posty</a><a class="dropdown-item" role="presentation" href="#add_friend_modal" data-toggle="modal" data-target="#add_friend_modal">Dodaj znajomego</a><a class="dropdown-item"
                                    role="presentation" href="logout.php">Wyloguj</a></div>
                        </li>
                    </ul>
            </div>
    </div>
    </nav>
    </div>
    <form action="adding.php" method="post">
    <div class="modal fade" role="dialog" tabindex="-1" id="add_post_modal">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Dodawanie posta</h4><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button></div>
                <div class="modal-body">
                    <p style="margin-bottom:8px;">Wpisz treść posta:</p><textarea name="content" style="width:100%;"></textarea>
                    </div>
                <div class="modal-footer"><button class="btn btn-primary" type="submit">Opublikuj</button></div>
            </div>
        </div>
    </div>
	</form>
   <form action="adding_friend.php" method="post">
    <div class="modal fade" role="dialog" tabindex="-1" id="add_friend_modal">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Dodawanie znajomego</h4><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button></div>
                <div class="modal-body">
                    <p style="margin-bottom:8px;">Wpisz adres e-mail osoby, którą chcesz dodać:</p><input type="email" name="mail" style="width:100%;"></div>
                <div class="modal-footer"><button class="btn btn-primary" type="submit">Dodaj</button></div>
            </div>
        </div>
    </div>
	</form>
    <div style="height:60px;"></div>
   
    <section>
       
        <div class="container" id="post">
            <?php
		if(isset($_GET['id']))
		{
			require_once("connect.php");
            $pdo = new PDO('mysql:host='.$host.';dbname='.$db_name.';charset=utf8', $db_user);
			$pdo -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $stm = $pdo -> prepare('select count(*) co from `user` where id=:id');
			$stm -> bindValue(':id', $_GET['id'], PDO::PARAM_STR);
			$stm ->execute();
			$row1=$stm->fetch();
			if($row1['co']==1)
			{
				$pdo -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            	$stm = $pdo -> prepare('select *  from `user` where id=:id ');
				$stm -> bindValue(':id', $_GET['id'], PDO::PARAM_STR);
				$stm -> execute();
				$r=$stm->fetch();
				echo '<div class="photo-card" style="background-color:green;">
                <div class="photo-details" style="color:rgb(69,144,218);width:100%;">
                    <div style="float:right;margin-top:-27px;margin-bottom:-20px;margin-left:0px;margin-right:-4.5%;">
                        
                </div>
                <p id="post_text" style="color:rgb(0,0,0);width:100%;"><h3 style="color:white;font-style: italic;">Posty użytkownika: '.$r['username'].'</h3>&nbsp; </p>
                
            </div>
        </div>';
				
				$pdo -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            	$stm = $pdo -> prepare('select *  from `post` where userid=:id ORDER BY id DESC');
				$stm -> bindValue(':id', $_GET['id'], PDO::PARAM_STR);
				$stm -> execute();
				while($row = $stm->fetch())
				{
					echo '<div class="photo-card" style="background-color:rgba(106,204,235,0.46);">
                <div class="photo-details" style="color:rgb(69,144,218);width:100%;">
                    <div style="float:right;margin-top:-27px;margin-bottom:-20px;margin-left:0px;margin-right:-4.5%;">
                        
                </div>
                <p id="post_text" style="color:rgb(0,0,0);width:100%;">'.'Data dodania: '.$row['data'].'<br/>'.'Treść:<br/>'.$row['content'].'&nbsp; </p>
                
            </div>
        </div>';
					
				}
			}
			else
			{
				echo '<h6 style="text-align: center; color:red">Uzytkownik nie istnieje!</h6>';
			}
		}
		else
		{
			echo '<h6 style="text-align: center; color:red">Niepoprawne id użytkownika!</h6>';
		}
					
		
		
		?>
        </div>
        <div style="height:16px;"></div>
    </section>
    <div class="footer-basic" style="width:100%;height:31px;padding:0px;">
        <footer>
            <p class="copyright" style="margin-top:0px;">To wszystkie posty tego użytkownika</p>
        </footer>
    </div>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/js/add_post_image.js"></script>
</body>

</html>