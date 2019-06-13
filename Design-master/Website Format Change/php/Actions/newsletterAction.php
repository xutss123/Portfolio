
/**
 * Created by PhpStorm.
 * User: Systeembeheer
 * Date: 19-3-2018
 * Time: 15:28
 */

<?php $connection = mysql_connect("localhost", "hr", "12345");
if (!$connection) {
    die('Could not connect: ' . mysql_error());
}

var $email = ".Email";

mysql_select_db("my_database");
$sql = "INSERT INTO Subscribers (EmailAddress) VALUES ('$_POST[$email]')";
mysql_query($sql);
if (mysql_affected_rows() > 0) {
    header('Location: http://www.example.com/STEP1/');
} else {
    echo "fail";
}

?>