<?php
include 'db.php';
$error = "";
if(isset($_POST['login'])){
    if($_POST['username']=="admin" && $_POST['password']=="1234"){
        $_SESSION['login']=true;
        header("Location: list.php");
    } else {
        $error="Wrong login";
    }
}
?>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Login</title>
<link rel="stylesheet" href="style.css">
</head>
<body>
<div class="form-container">
<h2>Admin Login</h2>
<form method="post">
<input type="text" name="username" placeholder="Username" required>
<input type="password" name="password" placeholder="Password" required>
<button name="login">Login</button>
<p class="error"><?= $error ?></p>
</form>
</div>
</body>
</html>