namespace HW4

module Main =
    open Argu
    open System

    type CLIArguments =
        | ArrayBubbleSort
        | ListBubbleSort
        | ListQuickSort
        | ArrayQuickSort
        | Pack32
        | Pack16
        | Unpack32
        | Unpack16
        | JokeOfTerekhov
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | ArrayBubbleSort -> "Bubble sort for array"
                | ListBubbleSort -> "Bubble sort for list"
                | ListQuickSort -> "Quicksort for list"
                | ArrayQuickSort -> "Quick sort for array"
                | Pack32 -> "Packing two 32bit numbers"
                | Pack16 -> "Packing four 16bit numbers"
                | Unpack32 -> "Unpacking 64bit number into two 32bit numbers"
                | Unpack16 -> "Unpacking 64bit number into four 16bit numbers"
                | JokeOfTerekhov -> "Terekhov's joke"


    [<EntryPoint>]
    let main (argv: string array) =
        let parser = ArgumentParser.Create<CLIArguments>(programName = "ProgrammingCourse")
        try
        let results = parser.Parse argv

        let funcForHW4 func1 func2 func3 =
            printfn "Enter path to input file: "
            let inputFile = Console.ReadLine () |> string
            printfn "Enter path to output file: "
            let outputFile = Console.ReadLine () |> string
            let result = func1 (func2 (inputFile))
            func3 outputFile result

        if results.Contains ArrayBubbleSort then funcForHW4 hw4.arrayBubbleSort hw4.readArray hw4.writeArray
        elif results.Contains ListBubbleSort then funcForHW4 hw4.listBubbleSort hw4.readList hw4.writeList
        elif results.Contains ListQuickSort then funcForHW4 hw4.listQuickSort hw4.readList hw4.writeList
        elif results.Contains ArrayQuickSort then funcForHW4 hw4.arrayQuickSort hw4.readArray hw4.writeArray

        elif results.Contains Pack32 then
            printfn "Enter two int32 numbers: "
            let x = Console.ReadLine () |> int32
            let y = Console.ReadLine () |> int32
            let result = hw4.pack32bitInto64 (x, y)
            printfn "%A" result

        elif results.Contains Unpack32 then
            printfn "Enter int64 number: "
            let x = Console.ReadLine () |> int64
            let result = hw4.unpack64bitInto32 x
            printfn "%A" result

        elif results.Contains Pack16 then
            printfn "Enter four int16 numbers:"
            let x = Console.ReadLine () |> int16
            let y = Console.ReadLine () |> int16
            let z = Console.ReadLine () |> int16
            let a = Console.ReadLine () |> int16
            let result = hw4.pack16bitInto64 (x, y, z, a)
            printfn "%A" result

        elif results.Contains Unpack16 then
            printfn "Enter int64 number: "
            let x = Console.ReadLine () |> int64
            let result = hw4.unpack64bitInto16 x
            printfn "%A" result

        elif results.Contains JokeOfTerekhov then
            printfn "Анекдот. Один человек предлагает другому коньяка и спрашивает:\n- Сколько?\n- 20\n- Чего 20?\n- А чего сколько?"

        else
            parser.PrintUsage() |> printfn "%s"
        0
        with
        | :? ArguParseException as ex ->
            printfn "%s" ex.Message
            1
        | ex ->
            printfn "Internal Error:"
            printfn "%s" ex.Message
            2


