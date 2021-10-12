#load "Library.fs"

open FizzBuzz.Lib
Parser.tryParse "2"
Parser.tryParse "tomato"

open Validator
ValidNumber.isValidNumber 42
ValidNumber.isValidNumber -100
ValidNumber.isValidNumber 0
ValidNumber.isValidNumber 4001

ValidNumber.isValidNumber 15
|> Option.map FizzBuzz.getFizzBuzzString
