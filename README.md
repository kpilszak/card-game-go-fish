<h1 align="right">Card Game Go Fish</h1><br>

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
This project is a Windows Forms Application.  
The main purpose is to have the most matches (sets of four cards of the same value).  
There are two other players.  
The game starts with 52-cards deck. Five cards are dealt to every player. Remaining cards are called a stock.  
Players start the queue requesting values (e.g. "Give me all your 7s."). Every player who has requested values must give them back. If no one has such values, the player must "go fish" and draw the card out of the stock.  
When the player collects the match, he places it on the table so that other players can see them all the time. If he gets ran out of cards, he needs to take five more cards from the stock.  
The game is over if there is no more cards on the stock. The winner is the one with the most matches.

## Technologies
Project is created with:
* C# (.NET)  
IDE: Visual Studio 2017

## Supports
* Windows 10

## Setup
To run this project, open in Windows this file: /card-game-go-fish/obj/Debug/card-game-go-fish.exe

## Sources
This project was created as an exercise from Jennifer Greene and Andrew Stellman book "Head First. C#".
