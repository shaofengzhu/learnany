# HTML

When we need to use different techlogies in a project, it's better to learn those differnet techlogies. The best way is to try it.

You could create a github repo, called "learn" and put various projects there. For example, you could first create an empty git repo and put your html code there.

## GIT setup
```
mkdir learn
cd learn
git init
```
Now, create a very simple readme.md file under the learn, and commit it.
```
git add readme.md
git commit -m "initial commit"
```

Now, create an empty repo in the github and connect your local repo with the github by
```
git remote add origin https://github.com/shaofengzhu/learnany.git
git push origin master
```

Now, you have everything setup.

## First HTML Page
It's time to create the first html page. Let's create a folder "html", and then add a file "hello-world.html".
```html
<html>
    <title>First Page</title>
    <body>Hello, World<body>
</html>
```

Now, you could use file explorer to find your hello-world.html file, then click on it. You will see the page is rendered in the browser.

## Allow your page to be accessed from github.
Let's also commit the change and push it to github.

You only need to update your github repo settings to enable your page to be accessed using github pages.

Please click "Settings" -> "Pages", then change the "Source" from "None" to "master".

Now, you could access your page using
```
https://shaofengzhu.github.io/learnany/html/hello-world.html
```
Please replace the URL with your own github name.

In the future, anything you pushed to the github will be immediately accessed by any user.

## Learn more for HTML from https://www.w3schools.com/html/
Please learn the basics and HTML Forms. You do not need to learn HTML Graphics, Media.


