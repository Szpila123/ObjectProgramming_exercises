class Fixnum

  def czynniki
    tab = []
    (1..(Integer.sqrt(self))).each{|val| if self % val == 0 then if self/val != val then tab.push( val, self/val ) else tab.push( val ) end end}
    return tab
  end

  def doskonala
    tab = self.czynniki
    suma = 0
    tab.each{ |val| suma += val if val != self }
    return suma == self
  end

  def slownie
    dict = { 0=>"zero", 1=>"jeden", 2=>"dwa", 3=>"trzy", 4=>"cztery", 5=>"piec", 6=>"szesc", 7=>"siedem", 8=>"osiem", 9=>"dziewiec" }
    napis = ""
    temp = self
    while temp > 0
      napis = dict[temp%10] + " " + napis;
      temp /= 10;
    end
    return napis
  end

  def ack(y)
    if self == 0 then return y + 1
    else if y == 0 then return (self - 1).ack(1)
    else return (self - 1).ack(self.ack(y-1))
    end
  end

end

print 9.czynniki, "\n"
print 2.ack(1), "\n"
print 6.doskonala, " ", 7.doskonala, "\n"
print 123.slownie, "\n"
end
