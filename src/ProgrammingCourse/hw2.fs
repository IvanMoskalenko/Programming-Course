namespace ProgrammingCourse
module hw2 =
    open System
    let first_task x = x*x*x*x+x*x*x+x*x+x+1.0
    let second_task y =
        let q = y*y                             // x^2
        let r = q + y                           // x^2+x
        q*r+r+1.0                               // x^2(x^2+x)+(x^2+x)+1=x^4+x^3+x^2+x+1
                                                // 2 умножения и 3 сложения
    let create_array number_of_elements =
        let created_array : int array = Array.zeroCreate number_of_elements
        printf "Теперь придётся ввести все элементы массива: "
        for i = 1 to number_of_elements do
            let element = Console.ReadLine() |> int
            created_array.[i-1] <- element
        created_array
    let third_task (created_array: int array) number_of_elements supremum =        
        printf "Индексы элементов массива, не больших, чем заданное число:"
        for i = 1 to number_of_elements do
            if created_array.[i-1] <= supremum then
                printf " "
                printf "%A" i
    let forth_task (created_array: int array) (limits_array: int array) number_of_elements =
        printf "Индексы элементов массива, лежащие вне диапазона: "
        for i = 1 to number_of_elements do
            if (created_array.[i-1] < limits_array.[0]) || (created_array.[i-1] > limits_array.[1]) then
                printf " "
                printf "%A" i
                
        
        
