
function Fibonacci(x)
	if x<=2 then
        return 1
    else
        local num1 = 1;
        local num2 = 1;
        for i=3 , x do
            num1,num2 = num2,num1+num2;
        end
        return num2 + num1;
    end
end


function Sum( ... )
    local t = {...}
    print(table.ToLson(t))
    local r = 0;
    for i=1,#t do
	    r = r + t[i]
    end
	return r
end


