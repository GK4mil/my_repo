<!DOCTYPE html>
<html style="height:100%;width:100%;">

<head>
    <meta charset="utf-8">
    <link rel="icon" type="image/png" href="logo.png" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>FaceLite</title>
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

<body style="width:100%;height:100%;">
    <div class="row register-form" style="background-image:url(&quot;assets/img/50537153_527244407763127_8987205855560597504_n.png&quot;);background-size:cover;background-repeat:no-repeat;background-position:center;">
        <div class="col-md-8 offset-md-2" style="background-repeat:no-repeat;background-size:contain;">
            <form class="custom-form" method="post" action="registration.php">
                <h1>Formularz rejestracji konta</h1>
                <?php
					session_start();
					if(isset($_SESSION['err']))
					{
						echo '<h6 style="text-align: center; color:red">Adres email już raz został użyty do rejestracji!</br></br> </h6>';
					unset($_SESSION['err']);
					}
					?>
                <div class="form-row form-group">
                    <div class="col-sm-4 label-column"><label class="col-form-label" for="name-input-field">Imię i nazwisko</label></div>
                    <div class="col-sm-6 input-column"><input class="form-control" name="username" type="text" id="name_text" required></div>
                </div>
                <div class="form-row form-group">
                    <div class="col-sm-4 label-column"><label class="col-form-label" for="email-input-field">Email </label></div>
                    <div class="col-sm-6 input-column"><input name="mail" class="form-control" type="email" id="email_text" required></div>
                </div>
                <div class="form-row form-group">
                    <div class="col-sm-4 label-column"><label  class="col-form-label" for="pawssword-input-field">Hasło</label></div>
                    <div class="col-sm-6 input-column"><input name="pass"class="form-control" type="password" id="pass_text" minlength="5"  required></div>
                </div>
                <div class="form-row form-group">
                    <div class="col-sm-4 label-column"><label class="col-form-label" for="repeat-pawssword-input-field">Potwierdź hasło</label></div>
                    <div class="col-sm-6 input-column"><input class="form-control" type="password" id="pass_text_confirm" minlength="5" required></div>
                </div><button class="btn btn-light submit-button" type="submit" id="reg_button">Zarejestruj</button></form>
        </div>
    </div>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/js/add_post_image.js"></script>
    <script>
		var password = document.getElementById("pass_text"), confirm_password = document.getElementById("pass_text_confirm");

		function validatePassword()
		{
  			if(password.value != confirm_password.value) 
			{
    			confirm_password.setCustomValidity("Passwords Don't Match");
  			}
			else 
			{
    			confirm_password.setCustomValidity('');
  			}
		}

		password.onchange = validatePassword;
		confirm_password.onkeyup = validatePassword;
	</script>
</body>

</html>