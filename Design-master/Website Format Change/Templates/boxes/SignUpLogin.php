<section id="main">
        <div class="FormContainer FormContainerSignUp">
            <form name=".SignUpForm" method="post" action="php/Login/signup.php" onsubmit="return valAllDonation()">
                <span>
                    <p>Name</p><input type="text" class="Textboxes" onclick="return normalState(this.id)" onblur="return valFirst(this.form.name,this.id, 0)" id=".FirstName" name="first" placeholder="First Name"/>
                </span>
            <span>
                    <input type="text" class="Textboxes" onclick="return normalState(this.id)" onblur="return valLast(this.form.name,this.id, 0)" id=".LastName" name="last" placeholder="Last Name"/>
                    <p class="emptyFields"></p>
                </span>

            <span>
                    <p>Email Address</p><input type="email" onclick="return emailNormalState(this.id)" onblur="return valEmail(this.form.name,this.id,1)" id=".Email" name="email" class="Textboxes TextboxesEmail" placeholder="Please enter an email." />
                    <p class="emptyFields"></p>
                </span>
            <span>
                    <p>Username</p><input type="text" id=".Username" onclick="return normalState(this.id)" onblur="return valFirst(this.form.name,this.id,2)" class="Textboxes" name="username" placeholder="Pick a username.." />
                    <p class="emptyFields"></p>
                </span>
                <span>
                    <p>Passsword</p><input type="password" onclick="return emailNormalState(this.id)" onblur="return valEmail(this.form.name,this.id,3)" id=".pwd" name="pwd" class="Textboxes TextboxesEmail" placeholder="Please enter a password." />
                    <p class="emptyFields"></p>
                </span>
            <button type="submit" name="submit" class="button buttonPositionSignUp">Sign up</button>
        </form>
        </div>
        <form name="login" method="post" class="FormContainer FormContainerLogin" action="php/Login/login.php">
            <input type="text" class="Textboxes TextboxLogin" name="uid" placeholder="Username/Email">
            <input type="password" class="Textboxes TextboxLogin" name="pwd" placeholder="Password">
            <button name="submit" type="submit" class="button buttonPositionSignUp">Log in</button>
        </form>
    </section>