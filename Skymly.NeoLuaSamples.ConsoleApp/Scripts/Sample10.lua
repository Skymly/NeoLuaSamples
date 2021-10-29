--[[
原生lua支持以下几种循环结构
wihle condition do end
repeat until condition
for start,end,step do  end	
还有以下迭代器
for i,v in ipairs(table_name) do end
for k,v in pairs(table_name) do end
除此之外 NeoLua中可以使用foreach关键字来遍历实现了System.Collections.IEnumerable接口的对象
foreach element in Collections do end 
]]

--make sampledata
local t1 = { 77 , 32 , 43 , 45 , 58 , 56 , 37 , 98 , 19 , 50 };
local t2 = {
	["IOS"] = 1234554,
	["Android"] = 4465454,
	["MacOS"] = 5454654,
	["Linux"] = 455624,
	["Windows"] = 6546540
};
local t3 = {
	IOS = 1234554,
	Android = 4465454,
	MacOS = 5454654,
	Linux = 455624,
	Windows = 6546540
};


-- for loop
for i=1,#t1 do --step默认值是1 可省缺
	print("t1的第"..i.."项是:"..t1[i])
end

-- while loop
local a = 0;
while a < 95 do
	a = math.random(100);
	print(a);
end


local b = 0;
repeat 
	b =  math.random(100);
until b >= 95


print("foreach  t1")
foreach item in t1 do
	print(item.Key..'\t'..item.Value)--item是KeyValuePair<object,object>
end

print("foreach  t2")
foreach item in t2 do
	print(item.Key..'\t'..item.Value)--item是KeyValuePair<object,object>
end
print()

print("foreach  t3")
foreach item in t3 do
	print(item.Key..'\t'..item.Value)--item是KeyValuePair<object,object>
end
print()

print("for i,v  t1")
for i,v in ipairs(t1) do
	print(i,v)
end
print()

print("for i,v  t2")
for i,v in ipairs(t2) do --因为t2是字典 所以无任何输出
	print(i,v)
end
print()

print("for i,v  t3") --因为t3是字典 所以无任何输出
for i,v in ipairs(t3) do 
	print(i,v)
end
print()

print("for k,v  t1")
for k,v in pairs(t1) do
	print(k,v)
end
print()

print("for k,v  t2")
for k,v in pairs(t2) do
	print(k,v)
end
print()

print("for k,v  t3")
for k,v in pairs(t3) do
	print(k,v)
end



--遍历.NET集合

--遍历数组
local arr = "HelloWorld".ToCharArray();
for i=0,arr.Length-1 do
	print(arr[i])
end
foreach item in arr do 
	print(item)
end

--遍历字典
const Dict typeof System.Collections.Generic.Dictionary[string,int];
local dict = Dict();
dict["Apple"] = 100;
dict["Android"] = 150;
foreach item in dict do
	print(item.Key,item.Value)
end





