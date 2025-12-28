<?php
include 'db.php';
if(!isset($_SESSION['login'])) header("Location: login.php");
$id=intval($_GET['id']);
$conn->query("DELETE FROM students WHERE id=$id");
header("Location: list.php");
?>