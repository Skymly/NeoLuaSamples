
local function MakeTable( num )
	local  t = {}
	local i = 0;
	while (i < num) do
		table.insert(t,math.random(0,100));
		i = i + 1;
	end
	return t;
end
local t = MakeTable(count);
local lson = table.ToLson(t,false);
print("array:"..json)
print("table:"..lson);

--注意 .NET数组下标从0开始 LuaTable下标默认从1开始

do 
	print("ForLoop CSharpArray  " .. json)
	
	for i=0 , array.Length-1 do
		print('array[' .. i .. ']' .. "\t" .. array[i])
	end

	print("WhileLoop CSharpArray  " .. json)
	local index:int = 0;
	while (index < array.Length) do
	  print('array[' .. index.. ']' ,"\t",array[index])
	   index = index + 1;
	end


	print("RepeatLoop CSharpArray  ".. json)
	local index2 =0;
	--因为repeat先执行再判断条件 因此这个场景下如果数组长度为0 需要注意IndexOutOfRange
	if array.Length > 0 then 
		repeat 
	
			print('array[' .. index2.. ']' ,"\t",array[index2])
			index2 = index2 + 1;
		until (index2 == array.Length)
	end
end



do
	print("ForLoop LuaTable  " .. lson)
	for i=1,#t do
		print('t[' .. i.. ']' ,"\t",t[i])
	end

	print("WhileLoop LuaTable  "..lson)
	local index:int = 1;
	while (index < #t) do
	   print('t[' .. index.. ']' ,"\t",t[index])
	   index = index + 1;
	end


	print("RepeatLoop LuaTable  "..lson)
	local index2 =1;
	--因为repeat先执行再判断条件 因此这个场景下如果Table长度为0 需要注意IndexOutOfRange
	if #t > 0 then 
		repeat 
			print('t[' .. index2.. ']' ,"\t",t[index2])
			index2 = index2 + 1;
		until (index2 > #t)
	end
end
