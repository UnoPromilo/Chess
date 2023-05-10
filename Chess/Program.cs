// See https://aka.ms/new-console-template for more information

using Chess;
using Chess.Console;

Board board = BoardFactory.CreateNewWithDefaultValues();
GameController gameController = new(board);
ConsoleGameController consoleGameController = new(gameController);
consoleGameController.Play();