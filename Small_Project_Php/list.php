<?php
include 'db.php';
if(!isset($_SESSION['login'])) header("Location: login.php");
$data = $conn->query("SELECT * FROM students");
?>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Students</title>
<link rel="stylesheet" href="style.css">
</head>
<body>
<div class="table-container">
<h2>Students List</h2>
<a href="add.php" class="link-btn">Add Student</a>
<table>
<tr><th>ID</th><th>Name</th><th>Email</th><th>Age</th><th>Action</th></tr>
<?php while($row=$data->fetch_assoc()){ ?>
<tr>
<td><?= $row['id'] ?></td>
<td><?= htmlspecialchars($row['name']) ?></td>
<td><?= htmlspecialchars($row['email']) ?></td>
<td><?= $row['age'] ?></td>
<td>
<a class="edit-btn" href="edit.php?id=<?= $row['id'] ?>">Edit</a>
<a class="delete-btn" href="delete.php?id=<?= $row['id'] ?>">Delete</a>
</td>
</tr>
<?php } ?>
</table>
<a href="logout.php" class="link-btn">Logout</a>
</div>
</body>
</html>