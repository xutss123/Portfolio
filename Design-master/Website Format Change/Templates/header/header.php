<body>
<header>
    <div class="container">
        <div id="branding">
            <h1><span class="highlight">We Care</span> Animal Shelter</h1>
        </div>
        <nav>
            <ul>
                <li class="current"><a href="index.php">Home</a></li>
                <li class="dropdown ">
                    <a href="javascript:void(0)" class="dropbtn">Rescues</a>
                    <ul class="dropdown-content drop">
                        <a href="dogs.html">Dogs</a>
                        <a href="cats.html">Cats</a>
                        <a href="smallanimals.html">Small Animals</a>
                    </ul>
                </li>
                <li><a href="../donations.html">Donations</a></li>
                <li class="dropdown">
                    <a href="javascript:void(0)" class="dropbtn">About Us</a>
                    <ul class="dropdown-content">
                        <a href="overview.html">Overview</a>
                        <a href="contact.html">Contact Us</a>
                        <a href="staff.html">Staff</a>
                        <a href="sponsors.html">Sponsors</a>
                    </ul>
                </li>
                <li><a href="info.html">Info</a></li>
                <?php
                if(isset($_SESSION['u_id'])) {
                    echo '<li><form action="php/Login/logout.php" method="POST">
                    <button type ="submit" name = "submit">Logout</button></form><li>';
                } else {
                    echo '<li><a href="signup.php">Log in/Sign Up</a></li>';
                }
                ?>
            </ul>
        </nav>
    </div>
</header>
