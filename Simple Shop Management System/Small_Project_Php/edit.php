<?php
include 'db.php';
if(!isset($_SESSION['login'])) header("Location: login.php");

$id=intval($_GET['id']);
$data=$conn->query("SELECT * FROM students WHERE id=$id")->fetch_assoc();

if(isset($_POST['update'])){
    $stmt=$conn->prepare("UPDATE students SET name=?,email=?,age=? WHERE id=?");
    $stmt->bind_param("ssii",$_POST['name'],$_POST['email'],$_POST['age'],$id);
    $stmt->execute();
    header("Location: list.php");
}
?>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Edit Student</title>
<link rel="stylesheet" href="style.css">
</head>
<body>
<div class="form-container">
<h2>Edit Student</h2>
<form method="post">
<input type="text" name="name" value="<?= htmlspecialchars($data['name']) ?>" required>
<input type="email" name="email" value="<?= htmlspecialchars($data['email']) ?>" required>
<input type="number" name="age" value="<?= $data['age'] ?>" required>
<button name="update">Update</button>
</form>
<a href="list.php" class="link-btn">Back</a>
</div>
</body>
</html>