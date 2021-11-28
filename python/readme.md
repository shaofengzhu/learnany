# Tutorials
1. Make A Python Website As Fast As Possible! https://www.youtube.com/watch?v=kng-mJJby8g

2. https://www.tutorialspoint.com/flask/index.htm

In this tutorial, it said that you should use Python 2.7, do not use Python 2.7 as it's OK ot use Python 3 on your machine.

You also do not need to use virtualenv. The virtualenv will make your code more complicated.

# Hello World
Create a file app.py.
```python
from flask import Flask
app = Flask(__name__)

@app.route("/")
def hello_world():
    return "Hello, World"

if __name__ == "__main__":
    app.run(debug=True)

```

When you run the code, 'python app.py', you could browse to http://127.0.0.1:5000/ and you will see the web site runs.

Please note that the above code is equavalent to
```python
from flask import Flask
app = Flask(__name__)

def hello_world():
    return "Hello World"

app.add_url_rule("/", 'hello', hello_world)

if __name__ == "__main__":
    app.run(debug=True)

```

The @app.route() way is a much easier way to define a function that will be executed.

# Login
We will have two pages, index.html and login.html.
1. When the user browser to index.html page, it will check whether there is a auth cookie. If there is no auth cookie, then redirect to login.html page. if there is auth cookie, the index.html page will display the current user's login name.

2. For login page, it will display a form. When the user type in user name and password, the Python code will check the user name and password against the database. If the user name and password are valid, it will set the response cookie and redirect to the index.html page.

## app.py
```python
from flask import Flask
from views import views
app = Flask(__name__)

app.register_blueprint(views, url_prefix = "/")

if __name__ == "__main__":
    app.run(debug=True)

```

## views.py
```python
from flask import Blueprint, render_template, redirect, request
from datetime import date

from flask.helpers import url_for

views = Blueprint(__name__, "views")

@views.route('/')
def index_page():
    login_name = request.cookies.get('auth-loginname')
    if login_name is None or len(login_name) == 0:
        return redirect(url_for('views.login_page'))
    return render_template('index.html', message = login_name)

@views.route('/login', methods = ["GET", "POST"])
def login_page():
    if request.method == 'POST':
        user_name = request.form.get("UserName")
        user_password = request.form.get("UserPassword")
        # we need to validate the user_name and user_password against a database
        resp = redirect(url_for('views.index_page'))
        resp.set_cookie('auth-loginname', user_name)
        return resp
    else:
        return render_template('login.html')
```

## templates/index.html
```html
<html>
    <head>
        <title>Hello</title>
    </head>
    <body>
        Hello, World {{ message }}
    </body>
</html>
```

## templates/login.html
```html
<html>
    <head>
        <title>Login</title>
    </head>
    <body>
        <form method="post">
            Login: <input type="text" name="UserName" />
            <br />
            Password: <input type="password" name="UserPassword" />
            <br />
            <input type="submit" value="Submit" />
        </form>
    </body>
</html>
```
