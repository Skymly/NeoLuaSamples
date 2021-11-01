--[[
for i,v in ipairs(table_name) do end
for k,v in pairs(table_name) do end
]]

--make sampledata
local t1 = { 77 , 32 , 43 , 45 , 58  };
local t2 = {
	["IOS"] = 1234554,
	["Android"] = 4465454,
	["MacOS"] = 5454654,
	["Linux"] = 455624,
	["Windows"] = 6546540
};
local lson1 = table.ToLson(t1,false);
local lson2 = table.ToLson(t2,false);

print("\n".."for i,v in ipairs  ".. type(t1)  .."\t" .. lson1)
for i,v in ipairs(t1) do
	print(i,v)
end

print("\n".."for k,v in pairs  ".. type(t1)  .."\t" .. lson1)
for k,v in pairs(t1) do
	print(k,v)
end
print("\n".."for k,v in pairs  ".. type(t2)  .."\t" .. lson2)
for k,v in pairs(t2) do
	print(k,v)
end

--自定义迭代器
local function MyPairs(t)
	local i = 0
	return function () i = i + 1; return t[i]; end;
end

print("\n".."自定义迭代器 for item in MyPairs  ".. type(t1)  .."\t" .. lson1)
for item in MyPairs(t1) do 
	print(item)
end
