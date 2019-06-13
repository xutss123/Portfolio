<?php

if(isset($_POST['submit'])){
    
    include_once 'dbh.php';
    $first = mysqli_real_escape_string($conn, $_POST['first']);
    $last = mysqli_real_escape_string($conn, $_POST['last']);
    $email = mysqli_real_escape_string($conn, $_POST['email']);
    $username = mysqli_real_escape_string($conn, $_POST['username']);
    $pwd = mysqli_real_escape_string($conn, $_POST['pwd']);

    //Error handling
    //check for empty fields
    if(empty($first) || empty($last) || empty($email) || empty($username) || empty($pwd)){      
    header("Location: ../../signup.html");  //?signup=empty for php
    exit();
    } else {
        //check if input chars are valid
        if (!preg_match("/^[a-zA-Z]*$/",$first) || !preg_match("/^[a-zA-Z]*$/",$last)) {
            header("Location: ../../signup.html");  //?signup=invalid for php
            exit();
        } else {
            //Check if email is valid
            if(!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                header("Location: ../../signup.html");  //?signup=email for php
                exit();
            } else {
                $sql = "SELECT * FROM logs WHERE user_name= '$username'";
                $result = mysqli_query($conn, $sql);
                $resultCheck = mysqli_num_rows($result);
                if($resultCheck > 0) {
                    header("Location: ../../signup.html");  //?signup=usertaken for php
                    exit();
                } else {
                    //Hashing pass
                    $hashedPwd = password_hash($pwd, PASSWORD_DEFAULT);
                    //insert user into db
                    $sql = "INSERT INTO logs (user_first, user_last, user_email, user_name, user_pwd) VALUES ('$first', '$last', '$email', '$username', '$hashedPwd');";

                    mysqli_query($conn, $sql);
                    header("Location: ../../signup.html");  //?signup=succes for php
                    exit();
                }
            }
        }
    }
} else {
    header("Location: ../../signup.html");
    exit();
}