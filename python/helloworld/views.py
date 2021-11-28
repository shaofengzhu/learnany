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
