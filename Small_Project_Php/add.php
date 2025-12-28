<?php
include 'db.php';
if(!isset($_SESSION['login'])) header("Location: login.php");

if(isset($_POST['add'])){
    $stmt=$conn->prepare("INSERT INTO students(name,email,age) VALUES(?,?,?)");
    $stmt->bind_param("ssi",$_POST['name'],$_POST['email'],$_POST['age']);
    $stmt->execute();
    header("Location: list.php");
}
?>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Add Student</title>
<link rel="stylesheet" href="style.css">
</head>
<body>
<div class="form-container">
<h2>Add Student</h2>
<form method="post">
<input type="text" name="name" placeholder="Name" required>
<input type="email" name="email" placeholder="Email" required>
<input type="number" name="age" placeholder="Age" required>
<button name="add">Add</button>
</form>
<a href="list.php" class="link-btn">Back</a>
</div>
</body>
</html>