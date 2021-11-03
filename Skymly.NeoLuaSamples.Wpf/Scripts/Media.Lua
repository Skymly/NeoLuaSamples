local Media = {}

const Color typeof System.Windows.Media.Color
const Brush typeof System.Windows.Media.Brush
const SolidColorBrush typeof System.Windows.Media.SolidColorBrush
const LinearGradientBrush typeof System.Windows.Media.LinearGradientBrush
const RadialGradientBrush typeof System.Windows.Media.RadialGradientBrush
const DrawingBrush typeof System.Windows.Media.DrawingBrush

function Media.ArgbBrush(a,r,g,b)	
	local a1,r1,g1,b1 = cast(byte,a),cast(byte,r),cast(byte,g),cast(byte,b);
	local color = Color.FromArgb(a1,r1,g1,b1);
	local brush:SolidColorBrush = SolidColorBrush(color);
	return brush;
end

function Media.RgbBrush(r,g,b)
	local r1,g1,b1 = cast(byte,r),cast(byte,g),cast(byte,b);
	local color = Color.FromRgb(r1,g1,b1);
	local brush:SolidColorBrush = SolidColorBrush(color);
	return brush;
end

function Media.GetBrush(...)
	local args = {...}
	local a,r,g,b;
	if #args ==1 then
		local arr = ...;
		if arr.Length == 4 then
			a,r,g,b = ...[0],...[1],...[2],...[3]
			return Media.ArgbBrush(a,r,g,b);
		elseif arr.Length ==3 then
			r,g,b = ...[0],...[1],...[2];
			return Media.RgbBrush(r,g,b);
		end
	elseif #args == 3 then
		return Media.RgbBrush(...);
	elseif #args == 4 then
		return  Media.ArgbBrush(...);
	end
	return nil;
end

return Media;




