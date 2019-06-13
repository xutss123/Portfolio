<?php

session_start();

if(isset($_POST['submit'])) {

    include 'dbh.php';

    $uid = mysqli_real_escape_string($conn, $_POST['uid']);
    $pwd = mysqli_real_escape_string($conn, $_POST['pwd']);

    //Error handling
    //Check for empties
    if (empty($uid) || empty($pwd)) {
        header("Location: ../../index.?login=errorEmpty");              //?login=errorEmpty
        exit();
    } else {
        $sql = "SELECT * FROM logs WHERE user_name= '$uid' OR user_email='$uid'";
        $result = mysqli_query($conn,$result);
        $resultCheck = mysqli_num_rows($result);
        if($resultCheck < 1) {
            header("Location: ../../index.php?login=erroruidNoExist");              //?login=erroruidNoExist
            exit();
        } else {
            if($row = mysqli_fetch_assoc($result)) {
                //De-hashing pass
                $HashedPwdCheck = passwordx_verify($pwd, $row['user_pwd']);
                if($HashedPwdCheck == false) {
                    header("Location: ../../index.php?login=errorpasswrong");              //?login=errorpasswrong
                    exit();
                } elseif ($HashedPwdCheck) {
                    //Log in
                    $_SESSION['u_id'] = $row['user_id'];
                    $_SESSION['u_first'] = $row['user_first'];
                    $_SESSION['u_last'] = $row['user_last'];
                    $_SESSION['u_email'] = $row['user_email'];
                    $_SESSION['u_name'] = $row['user_name'];

                    header("Location: ../../index.php?login=success");              //?login=succes
                    exit();
                }
            }
        }

    }
} else {
    header("Location: ../../index.php?login=error");              //?login=error
    exit();
}