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

<body style="background-image:url(&quot;assets/img/50537153_527244407763127_8987205855560597504_n.png&quot;);background-repeat:no-repeat;background-size:cover;background-position:center;">
    <div class="container-fluid">
        <div class="row mh-100vh">
            <div class="col-10 col-sm-8 col-md-6 col-lg-6 offset-1 offset-sm-2 offset-md-3 offset-lg-0 align-self-center d-lg-flex align-items-lg-center align-self-lg-stretch bg-white p-5 rounded rounded-lg-0 my-5 my-lg-0" id="login-block">
                <div class="m-auto w-lg-75 w-xl-50">
                    <h2 class="text-info font-weight-light mb-5" style="font-size:26px;">&nbsp;<img src="assets/img/50614311_679752745759793_4359461169161830400_n.png" style="height:60px;width:60px;">&nbsp;Zapraszamy!</h2>
                    <?php
					session_start();
					if(isset($_SESSION['logoutsuccess']))
					{
						echo '<h6 style="text-align: center; color:green">Wylogowano pomyślnie!</h6>';
						unset($_SESSION['logoutsuccess']);
						session_destroy();
					}
					elseif(isset($_SESSION['zalogowany']))
					{
						header('Location:main.php');
					}
					elseif(isset($_SESSION['success']))
					{
						echo '<h6 style="text-align: center; color:green">Zarejestrowano pomyślnie!</br> Możesz teraz zalogować się za pomocą danych podanych przy rejestracji!</h6>';
					unset($_SESSION['success']);
					}
					elseif(isset($_SESSION['logerr']))
					{
						echo '<h6 style="text-align: center; color:red">Email lub hasło są nieprawidłowe!</h6>';
					unset($_SESSION['logerr']);
					}
					
					
					?>
                    <form method="post" action="login.php">
                        <div class="form-group"><label class="text-secondary">Email</label><input class="form-control" type="text" name="mail" required="" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,15}$" inputmode="email"></div>
                        <div class="form-group"><label class="text-secondary">Hasło</label><input class="form-control" type="password" name="pass" minlength="5" required=""></div><button class="btn btn-info mt-2" type="submit">Zaloguj</button></form>
                    <p class="mt-3 mb-0"><a href="register.php" class="text-info small">Utwórz konto!</a></p>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/js/add_post_image.js"></script>
</body>

</html>