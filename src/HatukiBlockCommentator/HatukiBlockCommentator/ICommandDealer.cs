/***********************************************************************************************
*                                                                                              *
*                           Project Name : hatuki-block-commentator                            *
*                                                                                              *
*                                File Name :  ICommandDealer.cs                                *
*                                                                                              *
*                                     Programmer : Hatuki                                      *
*                                                                                              *
*                                     Create : 2024-05-12                                      *
*                                                                                              *
*                                     Update : 2024-05-13                                      *
*                                                                                              *
*----------------------------------------------------------------------------------------------*
*                                                                                              *
*                             Interface for command dealer logic.                              *
*                                                                                              *
*==============================================================================================*/


namespace HatukiBlockCommentator.Abstract;


/// <summary>
/// 整点抽象东西.
/// </summary>
internal interface ICommandDealer { bool Deal(string[] args); }
