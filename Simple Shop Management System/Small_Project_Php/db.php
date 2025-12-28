<?php
session_start();

$conn = new mysqli(
    "sql110.infinityfree.com", // MySql Hostname
    "if0_40287838", // MySQL username
    "2023mznexus", // PassWord
    "if0_40287838_school" // if0_40287838_school
);
if ($conn->connect_error) {
    die("Database connection failed");
}
?>