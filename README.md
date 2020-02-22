# TTOS0300 User Interface Course Project


* Jaber Askari M2947
* 2019 
* Version 1.00
* Link for youtube video presintation

# Presentation

Click on the image to watch the youtube video presentation of my project<br>
[![](/images/main2.png)](https://www.youtube.com/watch?v=EP7nB_wyQyA&feature=youtu.be "")


## Table of contents

* [Product Description](#introduction)
* [Application Description ](#application-description)
* [Installation](#installation)
* [About Application: Requirements, Usage and Features](#about-application-requirements-usage-and-features)
* [Implemented Functional Requirements](#implemented-functional-requirements)
* [Not Implemented Functional Requirements](#not-implemented-functional-requirements)
* [Non-Functional Requirements](#non-functionalrequirements)
* [Limitations to Consider](#limitations-to-consider)
* [General Features](#generalfeatures)
* [General Use Case(Actors, features)](#general-use-caseactors-features)
* [Class Diagram](#class-diagram)
* [Mysql tables database](#mysql-tables-database)
* [MyMDB Interface](#mymdb-interface)
* [Problems and Improvement](#current-problems-and-future-improvemen)
* [What I have learned, challenges and subjects I should imrove](#what-i-have-learned-challenges-and-subjects-i-should-imrove)
* [Developers of MyMDB](#developers-of-mymdb)
* [Self Grading](#self-grading)


# Introduction

![](images/logo.PNG) <br>

In this project I made a movie database application. Name of the application is MyMDB.
MyMDB is application that a user can search for movies, save movies informations in his/her own database using Mysql. User also can add a movie and delete a movie from his/her
own database. In additon,t application uses the TMDB API to fetch movie's information from the TMDB website each time the application opens or user search for something.
Adding a movie or deleting a movie from Mysql database is restricted to users who have an account in the application. Application can be used with out having an account but
user can only search for movies from the TMDB and see popular movies not anything else.



# Application Description


MyMDB application is meant for personal use generally. Users with out an account in the application can use the application for searching and getting information about movies, in
this case the information is fetched from the TMDB website using a free API.
If the user creats an account in the application, user can save the information of his/her personal movies in the server of
the application. Users with account can save, add, remove and search movies from his/her own personal movie database.
On the other hand if a user does not have an account in the service, he/she can onley search for movies and see the popular movies. 

## Installation

* In the instalaion procces the user should make an empty directory for the application and later chose it as istalation path.
* MyMDB has some dependency packages: Material Design Themes, Material Design Color, Mysql.Data , Newtonsoft.json


# About Application: Requirements, Usage and Features

## Implemented Functional Requirements



| RequirementD | Type | Description | 							
|:-:|:-:|:-:|
| FUNCTIONAL-REQ-C0001 | Functional Requirement | User can sign up to the service with his/her email address|
| FUNCTIONAL-REQ-C0002 | Functional Requirement | User can see popular movies in the word at the moment |
| FUNCTIONAL-REQ-C0003 | Functional Requirement | User can search for movies by inserting a key word|
| FUNCTIONAL-REQ-C0004 | Functional Requirement | User can search for movies based genre by selecting it from genre combo box|
| FUNCTIONAL-REQ-C0005 | Functional Requirement | User can search for movies based on year by selecting it from year combo box |
| FUNCTIONAL-REQ-C0006 | Functional Requirement | User can set a profile picture While creating an account|
| FUNCTIONAL-REQ-C0007 | Functional Requirement | User can Add movies to his personal movie database|
| FUNCTIONAL-REQ-C0008 | Functional Requirement | User can delete movies from his personal movie database|
| FUNCTIONAL-REQ-C0009 | Functional Requirement | User can See his personal information and profile picture|
| FUNCTIONAL-REQ-C0010 | Functional Requirement | User can see all his personal movie list|
| FUNCTIONAL-REQ-C0011 | Functional Requirement | User can see the poster, realse date, adult, title and description of movies|


## Not Implemented Functional Requirements

In the table below is listed all the requirement which are not implemented in the application.


| RequirementD | Type | Description | 							
|:-:|:-:|:-:|
| FUNCTIONAL-REQ-C0001 | Functional Requirement | User can add movies to his/her favorite list|
| FUNCTIONAL-REQ-C0002 | Functional Requirement | user can change his/her personal information|
| FUNCTIONAL-REQ-C0003 | Functional Requirement | User can delete his/her account|


## Non-Functional Requirements

### Security


| RequirementID | Type | Description | Features that is affected|								
|:-:|:-:|:-:|:-:|
| SECURITY-REQ-0001 | Non-Functional Security | The passwords are secured by MD5 encryption|								



### Usability

| RequirementID | Type | Description | 							
|:-:|:-:|:-:|
| USABILITY-REQ-0001 | Non-Functional Usability | The user can install the application on his/her windows computer|
| USABILITY-REQ-0002 | Non-Functional Usability | The user interface and designing have proper contrasts in colors to be destinguishable and easily readable for user|


## Limitations to Consider

| Id | description | Category |
|:-:|:-:|:-:|
| CONSTRAINT-REQ-S00001 | Constrain | User must be connected to Jamk server to be able to create an account |
| CONSTRAINT-REQ-S00002 | Constrain | User should be connected to Jamk server to be able to log in|


## General Features

|ID| Feature | Priority |Implementation|
| :-:| :-: | :-: | :-: |
| FT01 | Signing up into the application with email address | Important | Implementated|
| FT02 | Searching movies based on key word | Important |Implementated |
| FT03 | Searching movies based on year | Nice to have |Implementated |
| FT04 | Searching movies based on genre | Nice to have |Implementated |
| FT05 | Popular movies | Important |Implementated |
| FT06 | Adding movie to personal Mysql databse | Important |Implementated |
| FT07 | Deleting movie from personl database| Nice to have |Implementated |
| FT08 | Seeing poster and description of movies| Nice to have |Implementated |
| FT09 | Adding movies to favorite list| Nice to have |Not Implementated |
| FT10 | Deleting the account from application| Nice to have | Not Implementated |
| FT11 | Changing personal information| Nice to have |Not Implementated |


## General Use Case(Actors, features)

![](/images/uc.png)

# Class Diagram
![](/images/cd.png)


# Mysql tables database
In Mysql server I have made 3 tables for the application.
* User
* Movie
* Favorite List

At the picture below you can see the tables, columns, types and relationships:
![](/images/mysql-tables.PNG)

<br>

# MyMDB Interface

## The fist page that appears after running the application: 
![](/images/1.PNG)

<br>

## Login Page
![](/images/login.PNG)

<br>

## Main page after loging in into the account
![](/images/main.PNG)

<br>

## By clicking on Profile button user can see his/her personal information and all the movie in her/his personal database(Mysql)
![](/images/profile.PNG)





# Current Problems and Future Improvement

## Bugs and Problems
During the development of the application I have faced many different problems like using API to serve my propose and many other problems that I faced
and solved. But the problem that I have been able to solve or infact did not have time to solve are listed below:
* When application is installed on a new machine, but user already has an account in the service, the profile picture of the user will not appear. It is because
the profile pictures that has  been set when creating the account are stored locally on the instalation folder. In other word the profile picture of users stored locally
on the computer drive, so if the profile piture does not esixt on hard drive it will appear adn instead the defauld picture will show.

## Future Improvements
For improvement of MyMDB I am planning to make the Favorite list that did not had the time to work on. Adding the feature that users can delete and change their accounts.
Also in future I will add friend list for users. So user can chat with each other and see their freind's personal movie list.
For profile picuter problem the solution would be saving the profile pictures in cloud and getting them from internet when user signs in. 


# What I have learned, challenges and subjects I should imrove

This project took me about 80 hours and I have done it entirely alone. In this project I worked alot with API, Json and Mysql databse. beside that I used 
mattarial design Nuget pachage for user interface like icons. 
In the backend proccess I had used many different methods and algoritm that I did not know before.
In this course I learned alot, before this course I had no previous knowledge of UI. But now I am albe to make my own windows application with a fairly nice user interface. 

The subject that I should improve is MVVM system and data binding. It is a very useful method that could not use it much in my project.


# Developers of MyMDB
MyMDB is a project for user interface course of Jamk University of Applied Science.
MyMDB has been done entirely by Jaber Askari M2947. development of this application took about 80 hours.

# Self Grading
* Jaber Askar M2947
* Suggested Garad : 5
* I graded myself 5 becase I spent more than 80 hours on the application. Also I did all the requirements for the projects. Down there are all the things that I have done in this project:
    * Getting data from Mysql database
    * Inserting Data to Mysql databse
    * Getting Data from API of TMDB
    * Using Json and converting it to usabele data
    * Using Material Design package for icnos and user interface
    * Getting the image for profile picture from OpenDialogBox, saving it in the application directory, setting it for profile picuture and saving the path in mysql database





