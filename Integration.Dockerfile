FROM microsoft/dotnet:3.0-sdk
WORKDIR /app

# Setup Selenium with ChromeDriver
# https://tecadmin.net/setup-selenium-with-chromedriver-on-debian/
RUN apt-get update
RUN apt-get install -y curl unzip xvfb libxi6 libgconf-2-4
# Install java
RUN sudo apt-get install default-jdk 
# Install Google Chrome
RUN sudo curl -sS -o - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add -
RUN sudo echo "deb [arch=amd64]  http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google-chrome.list
RUN sudo apt-get -y update
RUN sudo apt-get -y install google-chrome-stable
# Install ChromeDriver
RUN wget https://chromedriver.storage.googleapis.com/2.41/chromedriver_linux64.zip
RUN unzip chromedriver_linux64.zip
# Configure ChromeDriver
RUN sudo mv chromedriver /usr/bin/chromedriver
RUN sudo chown root:root /usr/bin/chromedriver
RUN sudo chmod +x /usr/bin/chromedriver
# Install Selenium standalone server jar file 
RUN wget https://selenium-release.storage.googleapis.com/3.13/selenium-server-standalone-3.13.0.jar
# testng jar file
RUN wget http://www.java2s.com/Code/JarDownload/testng/testng-6.8.7.jar.zip
RUN unzip testng-6.8.7.jar.zip
# Start Chrome via Selenium Server
RUN xvfb-run java -Dwebdriver.chrome.driver=/usr/bin/chromedriver -jar selenium-server-standalone.jar

# setup the integration testing

COPY HomeBid.sln ./
COPY src ./src
COPY test ./test

# restore all projects
RUN dotnet restore HomeBid.sln
