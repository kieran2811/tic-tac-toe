﻿using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
public class Program{
    static string[] board = ["1","2","3","4","5","6","7","8","9"];

    static void Main(){
        // User will get greeted & functions called to run the code
        resetBoard();
        Console.WriteLine("Welcome to tic tac toe");
        Console.WriteLine("To take a turn enter the number from the space you want to use");
        while(true){
            Console.WriteLine("Would you like to: \nCPU(1)\nPlayer(2)\nExit(3)");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice){
                case 1: // Play CPU
                    Console.WriteLine("Playing CPU");
                    break;
                case 2: // Play Player
                    Console.Clear();
                    Console.WriteLine("Playing Player");
                    printBoard();
                    for(int i=0; i<9; i++){
                        if(i%2==0){
                            if (checkResult("O")==true){
                                Console.WriteLine("Player 2 wins!");
                                resetBoard();
                                break;
                            }
                            else{
                                player1Turn();
                                printBoard(); 
                            } 
                        }
                        else{
                            if (checkResult("X")==true){
                                Console.WriteLine("Player 1 wins!");
                                resetBoard();
                                break;
                            }
                            else{
                                player2Turn();
                                printBoard(); 
                            }                          
                        }
                    }
                    if (checkResult("X")==true){
                        Console.WriteLine("Player 1 Wins");
                        resetBoard();
                        break;
                    }
                    if(checkResult("O")==true){
                        Console.WriteLine("Player 2 Wins");
                        resetBoard();
                        break; 
                    }
                    else{
                        Console.WriteLine("Nobody wins, tie!");
                        resetBoard();
                        break;
                    }
                case 3: // Exit
                    break;
                default:
                    break;
            }

        }
    }
    public static void printBoard(){
        Console.Clear();
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
        Console.WriteLine("     |     |      ");
    }
    public static void editBoard(int index,string value){
        board.SetValue(value: value, index: index-1);
    }
    public static void resetBoard(){
        for(int i = 0; i < board.Length; i++){
            board.SetValue(value: Convert.ToString(i+1), index: i);
        }
    }
    public static void cpuChoice(){

    }
    public static bool checkResult(string player){
        // Check Columns
        if (board[0]==player && board[1]==player && board[2]==player){return true;}
        if (board[3]==player && board[4]==player && board[5]==player){return true;}
        if (board[6]==player && board[7]==player && board[8]==player){return true;}
        
        // Check Rows
        if (board[0]==player && board[3]==player && board[6]==player){return true;}
        if (board[1]==player && board[4]==player && board[7]==player){return true;}
        if (board[2]==player && board[5]==player && board[8]==player){return true;}

        // Check Diagonal
        if (board[0]==player && board[4]==player && board[8]==player){return true;}
        if (board[2]==player && board[4]==player && board[6]==player){return true;}
        else{
            return false;
        }
    }
    public static void player1Turn(){
        Console.WriteLine("Player 1 Turn (X)");
        string choice = Console.ReadLine();
        editBoard(Convert.ToInt32(choice),"X");
    }
    public static void player2Turn(){
        Console.WriteLine("Player 2 Turn (O)");
        string choice = Console.ReadLine();
        editBoard(Convert.ToInt32(choice),"O");
    }
}