# Install Java SE Development Kit 
https://www.oracle.com/java/technologies/downloads/

Please choose "Windows", "x64 Installer". It will install the Java SDK to the folder like
`C:\Program Files\Java\jdk-17.0.1`

Now, let's verify the environment JAVA_HOME is correct. Please type `set java` in the command window. It should show something like
```
C:\Users\shaozhu>set java
JAVA_HOME=C:\Program Files\Java\jdk-17.0.1
```
If the JAVA_HOME does not point to correct SDK, we need to update the environment variables.

# Install Tomcat
http://tomcat.apache.org/

Please install version Tomcat 9 instead of version 10.

Let's choose the "64-bit Windows zip" option. After download the zip file, please unzip it to c:\tomcat folder.

## Startup Tomcat
```
cd C:\tomcat\apache-tomcat-9.0.55\bin
startup.bat
```
we could browse to http://localhost:8080/ to check whether Tomcat is installed correctly.

# Eclipse IDE
When we create a web page, though we could use notepad++, it's better to use some IDE, which dramatically improve the productivity.

https://www.eclipse.org/downloads/packages/installer
