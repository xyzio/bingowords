using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Data.SQLite;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace Wizard
{

    class BingoWordWizard
    {
       // public List<Category> categories = new List<Category>();
        public Dictionary<string, List<WordList>> categories = new Dictionary<string, List<WordList>>();

        public BingoWordWizard()
        {
            //Read wizard file
            readWizardFile();

        }

        public void readWizardFile()
        {
            List<string> words = new List<string>("a:and:away:big:blue:can:come:down:find:for:funny:go:help:here:I:in:is:it:jump:little:look:make:me:my:not:one:play:red:run:said:see:the:three:to:two:up:we:where:yellow:you".Split(':'));
            writeList("Dolch sight words", "Pre-primer full list", words);

            words = new List<string>("a:and:away:big:blue:can:come:down:find:for:funny:go:help:here:I:in:is:it:jump:little:look:make:me:my:not".Split(':'));
            writeList("Dolch sight words", "Pre-primer list 1", words);

            words = new List<string>("in:is:it:jump:little:look:make:me:my:not:one:play:red:run:said:see:the:three:to:two:up:we:where:yellow:you".Split(':'));
            writeList("Dolch sight words", "Pre-primer list 2", words);

            words = new List<string>("all:am:are:at:ate:be:black:brown:but:came:did:do:eat:four:get:good:have:he:into:like:must:new:no:now:on:our:out:please:pretty:ran:ride:saw:say:she:so:soon:that:there:they:this:too:under:want:was:well:went:what:white:who:will:with:yes".Split(':'));
            writeList("Dolch sight words", "Primer full list", words);

            words = new List<string>("all:am:are:at:ate:be:black:brown:but:came:did:do:eat:four:get:good:have:he:into:like:must:new:no:now:on:with".Split(':'));
            writeList("Dolch sight words", "Primer list 1", words);

            words = new List<string>("our:out:please:pretty:ran:ride:saw:say:she:so:soon:that:there:they:this:too:under:want:was:well:went:what:white:who:will:yes".Split(':'));
            writeList("Dolch sight words", "Primer list 2", words);

            words = new List<string>("after:again:an:any:as:ask:by:could:every:fly:from:give:going:had:has:her:him:his:how:just:know:let:live:may:of:old:once:open:over:put:round:some:stop:take:thank:them:then:think:walk:were:when".Split(':'));
            writeList("Dolch sight words", "First Grade Full List", words);

            words = new List<string>("after:again:an:any:as:ask:by:could:every:fly:from:give:going:had:has:her:him:his:how:just:know:let:live:may:of".Split(':'));
            writeList("Dolch sight words", "First Grade List 1", words);

            words = new List<string>("him:his:how:just:know:let:live:may:of:old:once:open:over:put:round:some:stop:take:thank:them:then:think:walk:were:when".Split(':'));
            writeList("Dolch sight words", "First Grade List 2", words);

            words = new List<string>("always:around:because:been:before:best:both:buy:call:cold:does:don't:fast:first:five:found:gave:goes:green:its:made:many:off:or:pull:read:right:sing:sit:sleep:tell:their:these:those:upon:us:use:very:wash:which:why:wish:work:would:write:your".Split(':'));
            writeList("Dolch sight words", "Second Grade Full List", words);

            words = new List<string>("always:around:because:been:before:best:both:buy:call:cold:does:don't:fast:first:five:found:gave:goes:green:its:made:many:off:or:pull".Split(':'));
            writeList("Dolch sight words", "Second Grade List 1", words);

            words = new List<string>("many:off:or:pull:read:right:sing:sit:sleep:tell:their:these:those:upon:us:use:very:wash:which:why:wish:work:would:write:your".Split(':'));
            writeList("Dolch sight words", "Second Grade List 2", words);

            words = new List<string>("about:better:bring:carry:clean:cut:done:draw:drink:eight:fall:far:full:got:grow:hold:hot:hurt:if:keep:kind:laugh:light:long:much:myself:never:only:own:pick:seven:shall:show:six:small:start:ten:today:together:try:warm".Split(':'));
            writeList("Dolch sight words", "Third Grade Full List", words);

            words = new List<string>("about:better:bring:carry:clean:cut:done:draw:drink:eight:fall:far:full:got:grow:hold:hot:hurt:if:keep:kind:laugh:light:long:much".Split(':'));
            writeList("Dolch sight words", "Third Grade List 1", words);

            words = new List<string>("hot:hurt:if:keep:kind:laugh:light:long:much:myself:never:only:own:pick:seven:shall:show:six:small:start:ten:today:together:try:warm".Split(':'));
            writeList("Dolch sight words", "Third Grade List 2", words);

            words = new List<string>("apple:baby:back:ball:bear:bed:bell:bird:birthday:boat:box:boy:bread:brother:cake:car:cat:chair:chicken:children:Christmas:coat:corn:cow:day:dog:doll:door:duck:egg:eye:farm:farmer:father:feet:fire:fish:floor:flower:game:garden:girl:good-bye:grass:ground:hand:head:hill:home:horse:house:kitty:leg:letter:man:men:milk:money:morning:mother:name:nest:night:paper:party:picture:pig:rabbit:rain:ring:robin:Santa Claus:school:seed:sheep:shoe:sister:snow:song:squirrel:stick:street:sun:table:thing:time:top:toy:tree:watch:water:way:wind:window:wood".Split(':'));
            writeList("Dolch sight words", "Nouns", words);

            words = new List<string>("apple:baby:back:ball:bear:bed:bell:bird:birthday:boat:box:boy:bread:brother:cake:car:cat:chair:chicken:children:Christmas:coat:corn:cow:day".Split(':'));
            writeList("Dolch sight words", "Nouns List 1", words);

            words = new List<string>("dog:doll:door:duck:egg:eye:farm:farmer:father:feet:fire:fish:floor:flower:game:garden:girl:good-bye:grass:ground:hand:head:hill:home:horse".Split(':'));
            writeList("Dolch sight words", "Nouns List 2", words);

            words = new List<string>("house:kitty:leg:letter:man:men:milk:money:morning:mother:name:nest:night:paper:party:picture:pig:rabbit:rain:ring:robin:Santa Claus:school:seed:sheep".Split(':'));
            writeList("Dolch sight words", "Nouns List 3", words);

            words = new List<string>("shoe:Santa Claus:school:seed:sheep:sister:snow:song:squirrel:stick:street:sun:table:thing:time:top:toy:tree:watch:water:way:wind:window:wood:head".Split(':'));
            writeList("Dolch sight words", "Nouns List 4", words);

            words = new List<string>("Acapella :American:Bergere Bleue :Brick :Capriole Banon :Cheddar:Cojack :Colby :Colby-Jack :Cold Pack :Cougar Gold :Crowley :Cypress Grove Chevre :Dry Jack :Farmer :Fresh Jack :Hubbardston Blue Cow :Humboldt Fog :Idaho Goatster :Maytag Blue :Monterey Jack :Monterey Jack Dry :Muenster :Peekskill Pyramid :Pepper jack :Pinconning :Plymouth:Provel :Shelburne Cheddar :Sonoma Jack :Swiss :Goat:Tillamook Chedder".Split(':'));
            writeList("Foods", "American Cheese", words);

            words = new List<string>("backfield:ball carrier:blitz:block:complete pass:division:down:draft choice:drop back:drop kick:field goal:foul:free agent:fumble:goalpost:goal line:kickoff:midfield:play:posession:punt:pylon:rookie:Super Bowl:touchdown:NFL".Split(':'));
            writeList("Sports", "American football terms", words);

            words = new List<string>("German Shephard:Terrier:Greyhound:Whippet:Beagle:Coon Dogs:Spaniel:Pointer:Setter:Bedlingtons:Airedale:Scottish Terrier:Jack Terrier:Doberman:Husky:Samoyed:Newfoundland:St. Bernard:Spitz:Border Collie:Komondor:Maltese:Shi Tsu:Chihuahua:Chow:Dogo:Canary Island:Tosa Inu:Pitbull Terrier".Split(':'));
            writeList("Animals", "Dogs", words);

            words = new List<string>("Buffalo Bills:Miami Dolphins:New England Patriots:New York Jets:Baltimore Ravens:Cincinnati Bengals:Cleveland Browns:Pittsburgh Steelers:Houston Texans:Indianapolis Colts:Jacksonville Jaguars:Tennessee Titans:Denver Broncos:Kansas City Chiefs:Oakland Raiders:San Diego Chargers:Dallas Cowboys:New York Giants:Philadelphia Eagles:Washington Redskins:Chicago Bears:Detroit Lions:Green Bay Packers:Minnesota Vikings:Atlanta Falcons:Carolina Panthers:New Orleans Saints:Tampa Bay Buccaneers:Arizona Cardinals:St. Louis Rams:San Francisco 49'ers:Seattle Seahawks".Split(':'));
            writeList("Sports", "American football teams", words);

            words = new List<string>("Center:Offensive guard:Offensive tackle:Tight end:Wide receiver:Fullback:Running back:Quarterback:Defensive end:Defensive tackle:Nose guard:Linebacker:Cornerback:Safety:Kicker:Holder:Long snapper:Kick returner:Punter:Upback:Punt returner:Gunner:Wedge buster:Hands team:Nickelback".Split(':'));
            writeList("Sports", "American football positions", words);

            words = new List<string>(":Advantage Rule:Assist:Attacker:Banana Kick:Bicycle Kick:Break:Breakaway:Carrying the Ball:Center Line :Charge:Clear:Defender:Draw:Dribbling:End Line:Flick Header:Foot Trap:Foul:Hacking:Free Kick:Marking:Near Post :Obstruction:Offside:Offside Position:Outlet Pass:Overlap:Penalty Shot:Professional Foul:Save:Shielding:Small-sided Game:Tackling:Touch Line:Volley".Split(':'));
            writeList("Sports", "Soccer terms", words);

            words = new List<string>("backboard:backcourt:basket:court:cylinder:draft:dribble:dunk:NBA:floor:free throw:frontcourt:game clock:layup:March Madness:pass:period:rebound :posession:rookie:shot clock:3-on-3:weakside:tip-off:traveling".Split(':'));
            writeList("Sports", "Basketball terms", words);

            words = new List<string>("Blackberry:Blackcurrant:Blueberry:Boysenberry:Chinese wolfberry:Tibetan goji berry:Cranberry:Elderberries:Gooseberries:Huckleberries:June berries:juniper berries:Loganberries:Honeyberry:Marion berries:Mulberries:Raspberries:Redcurrants:Seabuckhthorn berries:Service berries:Strawberries:Tayberries:Cloudberry:Hackberry:Thimbleberry".Split(':'));
            writeList("Foods", "Berries", words);

            words = new List<string>("Engineer:Teacher:Doctor:Lawyer:Physicist:Journalist:Plumber:Electrician:Baker:Grocer:Mechanic:Principal:Biologist:Nurse:Astronaut:Carpenter:Farmer:Firefighter:Police officer:Veterinarian:Acrobat:Cosmonaut:Author:Beekeeper:Blacksmith".Split(':'));
            writeList("Occupations", "Jobs", words);

            words = new List<string>("Car:Train:Airplane:Horse:Bicycle:Skateboard:Walking:Running:Boat:Unicycle:Tricycle:Motorcycle:Rocket:Helicopter:Rickshaw:Sled:Hovercraft:Submarine:Monorail:Lorry:Autogyro:Skis:Glider:Funicular:Chariot".Split(':'));
            writeList("Transportation", "Types of Transporation", words);

            words = new List<string>("Hood:Roof:Steering Wheel:Seat:Door:Window:Speedometer:Radio:Spark plug:Engine:brake:Battery:Transmission:tires:Bonnet:axle:Tachometer:Air filter:Alternator:Automobile self starter:Bell housing:Belts:Brakes :Anti-lock braking system:Bumper:Battery:Camshaft:Catalytic converter:Car door:Carburettor:Clutch:Connecting rod:Crankshaft:Cylinder head:Dashboard:Differential:Drive shaft:Distributor:Electronic Control Unit ECU:Electronic fuel injection:Exhaust gas recirculation:Exhaust manifold:Exhaust pipe:Exhaust valve:Fuel injector:Fuel pump:Fuel tank:Fuse:Gasket:Gearbox:Grille:Gudgeon pin:Hand brake:Hazard lights:Head gasket:Headlight:Ignition coil:Indicator light:Intake manifold:Intake valve:Kingpin:Manifold:Muffler:Odometer:Oil filter:Oil pump:Oil sump:Piston:Piston ring:Positive Crankcase Ventilation:PCV valve:Rack and pinion:Radiator:Rear-view mirror:Rocker arm:Rocker covers:Seat:Bench seat:Bucket seat:Seat belt:Spark plug:Speedometer:Starter ring gear:Steering wheel:Tachometer:Tailpipe:Tappet cover:Thermostat:Timing belt:Transmission:Universal joint:Water pump:Windscreen wiper:Windshield:Wing mirro".Split(':'));
            writeList("Transportation", "Parts of a Car", words);

            words = new List<string>("A:B:C:D:E:F:G:H:I:J:K:L:M:N:O:P:Q:R:S:T:U:V:W:X:Y:Z".Split(':'));
            writeList("Alphabet", "Letters", words);

            words = new List<string>("Algeria :Angola :Benin :Botswana :Burkina Faso :Burundi :Cameroon :Cape Verde :Central African Rep :Chad :Congo :Dem. Rep. Congo (Zaire) :Djibouti :Egypt :Equatorial Guinea :Eritrea :Ethiopia :Gabon :Gambia :Ghana :Guinea Bissau :Guinea :Ivory Coast :Kenya :Lesotho :Liberia :Libya :Madagascar :Malawi :Mali :Mauritania :Mauritius :Morocco :Mozambique :Namibia :Niger :Nigeria :Reunion :Rwanda :São Tomé and Principe :Senegal :Seychelles :Sierra Leone :Somalia :South Africa :Sudan :Swaziland :Tanzania :Togo :Tunisia :Uganda :Zambia :Zanzibar :Zimbabwe  ".Split(':'));
            writeList("Geography", "African Countries", words);

            words = new List<string>("Abuja-Nigeria:Accra-Ghana:Addis Ababa-Ethiopia:Algiers-Algeria:Antananarivo-Madagascar:Asmara-Eritrea:Bamako-Mali:Bangui-Central African Republic:Banjul-Gambia:Bissau-Guinea-Bissau:Brazzaville-Rep. Congo:Bujumbura-Burundi:Cairo-Egypt:CapeTown-South Africa:Conakry-Guinea:Dakar-Senegal:Djibouti-Djibouti:Dodoma-Tanzania:Freetown-Sierra Leone:Gaborone-Botswana:Harare-Zimbabwe:Jamestown-Saint Helena:Kampala-Uganda:Khartoum-Sudan:Kigali-Rwanda:Kinshasa-DR Congo:Libreville-Gabon:Lilongwe-Malawi:Lobamba-Swaziland:Lomé-Togo:Luanda-Angola:Lusaka-Zambia:Malabo-Equatorial Guinea:Mamoudzou-Mayotte:Maputo-Mozambique:Maseru-Lesotho:Mbabane-Swaziland:Mogadishu-Somalia:Monrovia-Liberia:Moroni-Comoros:Nouakchott-Mauritania:Niamey-Niger:N'Djamena-Chad:Nairobi-Kenya:Ouagadougou-BurkinaFaso:PortLouis-Mauritius:Porto-Novo-Benin:Praia-CapeVerde:Rabat-Morocco:Saint-Denis-Réunion:SãoTomé-São Tomé and Príncipe:Tripoli-Libya:Tunis-Tunisia:Victoria-Seychelles:Windhoek-Namibia:Yaoundé-Cameroon:Yamoussoukro-Côte d'Ivoire".Split(':'));
            writeList("Geography", "African Capitals", words);

            words = new List<string>("AL:AK:AZ:AR:CA:CO:CT:DE:FL:GA:HI:ID:IL:IN:IA:KS:KY:LA:ME:MD:MA:MI:MN:MS:MO".Split(':'));
            writeList("Geography", "US State Abbreviations A-MO", words);

            words = new List<string>("MT:NE:NV:NH:NJ:NM:NY:NC:ND:OH:OK:OR:PA:RI:SC:SD:TN:TX:UT:VT:VA:WA:WV:WI:WY".Split(':'));
            writeList("Geography", "US State Abberviations MT-WY", words);

            words = new List<string>("Alabama:Alaska:Arizona:Arkansas:California:Colorado:Connecticut:Delaware:Florida:Georgia:Hawaii:Idaho:Illinois:Indiana:Iowa:Kansas:Kentucky:Louisiana:Maine:Maryland:Massachusetts:Michigan:Minnesota:Mississippi:Missouri:Montana:Nebraska:Nevada:New Hampshire:New Jersey:New Mexico:New York:North Carolina:North Dakota:Ohio:Oklahoma:Oregon:Pennsylvania:Rhode Island:South Carolina:South Dakota:Tennessee:Texas:Utah:Vermont:Virginia:Washington:West Virginia:Wisconsin:Wyoming".Split(':'));
            writeList("Geography", "All US States", words);

            words = new List<string>("Alabama:Alaska:Arizona:Arkansas:California:Colorado:Connecticut:Delaware:Florida:Georgia:Hawaii:Idaho:Illinois:Indiana:Iowa:Kansas:Kentucky:Louisiana:Maine:Maryland:Massachusetts:Michigan:Minnesota:Mississippi:Missouri".Split(':'));
            writeList("Geography", "US States A-Mi", words);

            words = new List<string>("Montana:Nebraska:Nevada:New Hampshire:New Jersey:New Mexico:New York:North Carolina:North Dakota:Ohio:Oklahoma:Oregon:Pennsylvania:Rhode Island:South Carolina:South Dakota:Tennessee:Texas:Utah:Vermont:Virginia:Washington:West Virginia:Wisconsin:Wyoming".Split(':'));
            writeList("Geography", "US States Mo-W", words);

            words = new List<string>("AL:AK:AZ:AR:CA:CO:CT:DE:FL:GA:HI:ID:IL:IN:IA:KS:KY:LA:ME:MD:MA:MI:MN:MS:MO:MT:NE:NV:NH:NJ:NM:NY:NC:ND:OH:OK:OR:PA:RI:SC:SD:TN:TX:UT:VT:VA:WA:WV:WI:WY".Split(':'));
            writeList("Geography", "All US State Abbreviations", words);

            words = new List<string>("AL:AK:AZ:AR:CA:CO:CT:DE:FL:GA:HI:ID:IL:IN:IA:KS:KY:LA:ME:MD:MA:MI:MN:MS:MO".Split(':'));
            writeList("Geography", "US State Abbreviations AL-MO", words);

            words = new List<string>("MT:NE:NV:NH:NJ:NM:NY:NC:ND:OH:OK:OR:PA:RI:SC:SD:TN:TX:UT:VT:VA:WA:WV:WI:WY".Split(':'));
            writeList("Geography", "US State Abbreviations MT-WY", words);

            words = new List<string>("9 x 0:9 x 1:9 x 2:9 x 3:9 x 4:9 x 5:9 x 6:9 x 7:9 x 8:9 x 9:9 x 10:9 x 11:9 x 12:9 x 13:9 x 14:9 x 15:9 x 16:9 x 17:9 x 18:9 x 19:9 x 20:9 x 21:9 x 22:9 x 23:9 x 24:9 x 25".Split(':'));
            writeList("Math", "Multiplication by 9", words);

            words = new List<string>("1:2:3:4:5:6:7:8:9:10:11:12:13:14:15:16:17:18:19:20:21:22:23:24:25".Split(':'));
            writeList("Math", "Numbers 1-25", words);

            words = new List<string>("one:two:three:four:five:six:seven:eight:nine:ten:eleven:twelve:thirteen:fourteen:fifteen:sixteen:seventeen:eighteen:nineteen:twenty:twenty-one:twenty-two:twenty-three:twenty-four:twenty-five".Split(':'));
            writeList("Math", "Numbers one to twenty-five", words);
            
            words = new List<string>("one:two:three:four:five:six:seven:eight:nine:ten:eleven:twelve:thirteen:fourteen:fifteen:sixteen:seventeen:eighteen:nineteen:twenty:twenty-one:twenty-two:twenty-three:twenty-four:twenty-five".Split(':'));
            writeList("Math", "Numbers one to twenty-five", words);

            words = new List<string>("acorns:America:applepie:Autumn:bake:baste:blessings:bread:canoe:carve:casserole:celebrate:centerpiece:cider:colonists:cook:corn:cornbread:cornucopia:cranberries:delicious:dessert:dinner:dish:drumstick:eat:Fall:family:feast:giblets:gobble:grandparents:gratitude:gravy:ham:harvest:holiday:home:Indians:leaves:leftovers:maize:Massachusetts:Mayflower:meal:nap:napkin:native:NewWorld:November:oven:pans:parade:pecanpie:pie:Pilgrims:plantation:planting:plate:platter:Plymouth:pots:prayer:pumpkin:pumpkinpie:Puritans:recipe:religion:roast:rolls:sail:sauce:seasons:serve:settlers:sleep:snow:squash:stir:stuffing:tablecloth:thanks:Thanksgiving:Thursday:tradition:travel:tray:treaty:turkey:vegetables:voyage:Winter:wishbone:yams".Split(':'));
            writeList("Holidays", "Thanksgiving full list", words);

            words = new List<string>("acorns:America:applepie:Autumn:bake:baste:blessings:bread:canoe:carve:casserole:celebrate:centerpiece:cider:colonists:cook:corn:cornbread:cornucopia:cranberries:delicious:dessert:dinner:dish:drumstick:eat:Fall:family:feast:giblets:gobble".Split(':'));
            writeList("Holidays", "Thanksgiving  A-G", words);

            words = new List<string>("grandparents:gratitude:gravy:ham:harvest:holiday:home:Indians:leaves:leftovers:maize:Massachusetts:Mayflower:meal:nap:napkin:native:NewWorld:November:oven:pans:parade:pecanpie:pie:Pilgrims:plantation:planting:plate:platter:Plymouth:pots".Split(':'));
            writeList("Holidays", "Thanksgiving  G-P", words);

            words = new List<string>("prayer:pumpkin:pumpkinpie:Puritans:recipe:religion:roast:rolls:sail:sauce:seasons:serve:settlers:sleep:snow:squash:stir:stuffing:tablecloth:thanks:Thanksgiving:Thursday:tradition:travel:tray:treaty:turkey:vegetables:voyage:Winter:wishbone".Split(':'));
            writeList("Holidays", "Thanksgiving  P-W", words);

            words = new List<string>("Advent:angels:announcement:bells:Bethlehem:Blitzer:candles:candy:candycanes:cards:cedar:celebrate:ceremonies:chimney:cookies:Comet:cranberry:crowds:Cupid:Dancer:Dasher:December:decorations:dolls:Donner:dressing:eggnog:elves:family:festival:fir:Frosty:fruitcake:gifts:goodwill:greetings:ham:happy:holiday:holly:holy:icicles:Jesus:jolly:lights:lists:merry:miracle:mistletoe:NewYear:Noel:NorthPole:pageant:parades:party:pie:pine:plumpudding:poinsettia:Prancer:presents:pumpkinpie:punch:red:green:reindeer:ribbon:Rudolph:sacred:sauce:Scrooge:season:sled:sleigh:snowflakes:spirit:St.Nick:stand:star:stickers:stocking:sweetpotato:tidings:tinsel:toys:tradition:traffic:trips:turkey:vacation:Vixen:Winter:wisemen:worship:wrappingpaper:wreath:xmas:yam:yule:yuletide".Split(':'));
            writeList("Holidays", "Christmas Full List", words);

            words = new List<string>("Advent:angels:announcement:bells:Bethlehem:Blitzer:candles:candy:candycanes:cards:cedar:celebrate:ceremonies:chimney:Comet:cookies:cranberry:crowds:Cupid:Dancer:Dasher:December:decorations:dolls:Donner".Split(':'));
            writeList("Holidays", "Christmas A-D", words);

            words = new List<string>("dressing:eggnog:elves:family:festival:fir:Frosty:fruitcake:gifts:goodwill:green:greetings:ham:happy:holiday:holly:holy:icicles:Jesus:jolly:lights:lists:merry:miracle:mistletoe".Split(':'));
            writeList("Holidays", "Christmas D-M", words);

            words = new List<string>("New Year:Noel:North Pole:pageant:parades:party:pie:pine:plumpudding:poinsettia:Prancer:presents:pumpkin:punch:red:reindeer:ribbon:Rudolph:sacred:sauce:Scrooge:season:sled:sleigh:snowflakes".Split(':'));
            writeList("Holidays", "Christmas N-S", words);

            words = new List<string>("spirit:St.Nick:stand:star:stickers:stocking:sweetpotato:tidings:tinsel:toys:tradition:traffic:trips:turkey:vacation:Vixen:Winter:wisemen:worship:wrappingpaper:wreath:xmas:yam:yule:yuletide".Split(':'));
            writeList("Holidays", "Christmas S-Y", words);

            /*            List<string> words = new List<string>("a and away big blue can come down find for funny go help here I in is it jump little look make me my not".Split(' '));
                        writeList("Dolch Sight Word List", "Pre-Primer List 1", words);

                        words = new List<string>("one play my not red run make me said see the little look three to two up we it jump where yellow you in is".Split(' '));
                        writeList("Dolch Sight Word List", "Pre-Primer List 2", words);

             /*           words = new List<string>("one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen twenty twentyone twentytwo twentythree twentyfour twentyfive".Split(' '));
                        writeList("Numbers", "one to twentyfive", words);

                        words = new List<string>("onebingo twobingo threebingo foubingor fivebingo sixbingo sevenbingo eight nine ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen twenty twentyone twentytwo twentythree twentyfour twentyfive".Split(' '));
                        writeList("Numbers", "one to twentyfivebingo", words);

                        words = new List<string>("absorb abstract accurate advocate aid biology category client code compound confront contract contrary crisis deny dictate diffuse dispute duration edit electron enlighten err execute expel fraud grant graph gravity homogeneous implement impose incorporate insist institute instruct intersect interval job kindred label legitimate objective overlap parenthesis perpetrate preliminary radius respond restore retain retard rudimentary secure stimulate stress style subtle superior supplement suppress symptom synthetic tiny trait transfer transform trivial vast version".Split(' '));
                        writeList("Words", "A bunch of words", words);*/
        }

        public void writeList(string category, string listName, List<string> words)
        {
            if (categories.ContainsKey(category) == false)
            {
                categories.Add(category, new List<WordList>());
            }
            categories[category].Add(new WordList(listName, words));

        }
    }

    class Category
    {
        public string name;
        public List<WordList> list = new List<WordList>();

        public Category (string name)
        {
            this.name = name;
        }

        public void addList(string name, List<string> words)
        {
            this.list.Add(new WordList(name, words));
        }
        public void getList(string name)
        {

        }
    }

    class WordList
    {
        public string name;
        public List<string> words;

        public WordList(string name, List<string> words)
        {
            this.name = name;
            this.words = words;
        }
    }
}

namespace BingoWords
{
    class BingoFuncs
    {
    }

    class BingoLinks
    {

        public string mainSiteLink = "http://xyzio.com/BingoWordsWebsite/Default.aspx";
        public string purchaseSiteLink = "http://xyzio.com/BingoWordsWebsite/Purchase/Default.aspx";

        public BingoLinks()
        {

            return;
        }

    }



    class BingoTable
    {
        public int rowSize;
        public int colSize;

        public int previewSizeX;
        public int previewSizeY;
        public int previewHeight;
        public int previewWidth;

        public int numCardsToPrint;
        public int numCardsPerPage;

        public bool printCallList = true;

        public bool printTitle;
        public string titleText;

        public bool printFreeSpace;
        public string freeSpaceText;

        public string filePath;

        public List<string> items;

        public BingoPrint PrintBingo = new BingoPrint();

        public BingoFileFuncs DB = new BingoFileFuncs();

        public int RandSeed = 0; //To keep the preview from switching around on resize.  When printng we will either give this a pre-determined number or a random number based on License information

        public BingoTable(string filePath)
        {
            BingoWordFile file = new BingoWordFile(filePath);
            file = DB.openFile(filePath);
            this.filePath = file.filePath;
            this.items = new List<string>(file.wordList);
            this.titleText = file.cardTitleText;
            this.freeSpaceText = file.cardFreeSpaceText;
            if (file.cardRowSize > 0)
            {
                this.rowSize = file.cardRowSize;
            }
            else
            {
                this.rowSize = 5;
            }
            if (file.cardColSize > 0)
            {
                this.colSize = file.cardColSize;
            }
            else
            {
                this.colSize = 5;
            }
            this.numCardsToPrint = file.numCardsToPrint;
            this.numCardsPerPage = file.numCardsPerPage;
            this.printTitle = file.printTitle;
            this.printFreeSpace = file.printFreeSpace;
        }

        public BingoTable(List<string> words)
        {
            this.rowSize = this.colSize = 5;

            this.printTitle = false;
            this.printFreeSpace = false;

            this.printCallList = true;

            this.numCardsPerPage = 1;
            this.numCardsToPrint = 1;

            this.filePath = null;
            this.freeSpaceText = "Free Space!";
            this.titleText = "BINGO";
            items = new List<string>(words);

        }

        public BingoTable(int rowSize, int colSize)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;

            this.printTitle = false;
            this.printFreeSpace = false;

            this.printCallList = true;

            this.numCardsPerPage = 1;
            this.numCardsToPrint = 1;

            this.filePath = null;

            items = new List<string>();

        }
    }

    class BingoLicense
    {
        private string code = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123!@#";
        private string secret = "SAFBUCMDSEKF!#%";
		private string secret2 = "fj*U#%IJifJ:23";
        public bool isLicensed;
        //public string name;
        private string license;
        public string licenseText;
        public int maxItems = 25;
        public int maxNumCardsToPrint = 15;

        public void readLicenceFile()
        {

            license = "";
            licenseText = "This copy of Bingo Card Designer is not licensed.";
            isLicensed = false;


            string licensePath = Application.StartupPath;
            licensePath = Path.Combine(licensePath, "license.txt");

            if (File.Exists(licensePath))
            {

                FileStream file = new FileStream(licensePath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                while (sr.EndOfStream != true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                    {
                        continue;
                    }
                    line = line.ToUpper();
                    if (line.Contains("LICENSE: "))
                    {
                        Regex licenseRegex = new Regex("LICENSE: (.+)");
                        string[] results = licenseRegex.Split(line);

                        foreach (string item in results)
                        {
                            {
                                if (item != "")
                                {
                                    license = item;
                                    break;
                                }
                            }
                        }
                    }

                    //   line = sr.ReadLine();
                }
                sr.Close();
                file.Close();

                if ((this.license != null))
                {
                    if (this.readLicence() == true)
                    {
                        licenseText = "This copy of Bingo Card Designer is licensed.\n\nLicense: " + license;
                        isLicensed = true;
                    }

                    else
                    {
                      
                        license = "";
                        isLicensed = false;
                        licenseText = "This copy of Bingo Card Designer is not licensed.";
                    }

                    return;
                }
            }
            
            license = "";
            isLicensed = false;
            licenseText = "This copy of Bingo Card Designer is not licensed.";

        }

        public BingoLicense()
        {
            this.readLicenceFile();
        }//Here we will get License info in the future

				public void writeToLicenceFile(string fileName, string licenseString) {
					string licensePath = Application.StartupPath;
					licensePath = Path.Combine(licensePath, fileName);

					if (File.Exists(licensePath)) {
						try {
							File.Delete(licensePath);
						}
						catch {
						}
					}
					FileStream file = new FileStream(licensePath, FileMode.OpenOrCreate, FileAccess.Write);
					StreamWriter sw = new StreamWriter(file);

					string license = "license: " + licenseString;

					sw.WriteLine(license);
					sw.Close();
					file.Close();
				}

        public bool readLicence()
        {
            return (Decrypt(license));
        }

        private bool Decrypt(string licence)
        {
            string[] splitLicense = licence.Split('-');

            string plainText = (secret2 + splitLicense[0] + secret).ToUpper();

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Because we support multiple hashing algorithms, we must define
            // hash object as a common (abstract) base class. We will specify the
            // actual hashing algorithm class later during object creation.
            HashAlgorithm hash = new SHA1Managed();

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);
            char[] returnChar = Convert.ToBase64String(hashBytes).ToCharArray();
            hashBytes = null;

            string returnString = "";
            for (int i = 0; i < returnChar.Length; i++)
            {
                if (returnString.Length >= 8)
                {
                    break;
                }
                if (((returnChar[i] >= 48) && (returnChar[i] <= 57)) || ((returnChar[i] >= 65) && (returnChar[i] <= 90)) || ((returnChar[i] >= 97) && (returnChar[i] <= 122)))
                {
                    returnString += returnChar[i].ToString().ToUpper();
                }
            }

            if (returnString.Length < 8)
            {
                //Pad the rest with 0
                while (returnString.Length < 8)
                {
                    returnString += "0";
                }
            }

						try {
							licence = splitLicense[1] + splitLicense[2];
						}
						catch {
							return (false);
						}

            if (licence == returnString)
            {
                return (true);
            }

            return (false);
        }

    }

    class BingoPrint
    {
        PrintDocument printBingoDocument;
        PrintPreviewDialog printBingoPreviewDialog;
        PrintDialog printBingoDialog;
        PageSetupDialog pageBingoSetupDialog;
        PageSettings PrintPageSettings;
        BingoTable bingoTable;
        bool printCallListOnNextPage = false;
	//		QueryPageSettings
//StartPage
//PrintPage
//EndPage
//http://msdn.microsoft.com/en-us/library/system.drawing.printing.printdocument.querypagesettings.aspx
//http://stackoverflow.com/questions/621095/diferent-orientation-ina-multiple-page-printdocument-how-to
        int numCardsToPrint;

        /*
         *                     if (bingoTable.printCallList == true)
                    {
                        printBingoCallList(pt, sz, bingoTable, Color.Black, ref graphicsObj, licenseInfo, "Oranges are pink", false);
                        //print the call list here - msk
                    }
                    bingoTable.RandSeed = 0;
         * */
        public BingoPrint()
        {
            printBingoDocument = new PrintDocument();
            //printCallList = new PrintDocument();
            printBingoPreviewDialog = new PrintPreviewDialog();
            printBingoDialog = new PrintDialog();
            pageBingoSetupDialog = new PageSetupDialog();
            PrintPageSettings = new PageSettings();
			printBingoDocument.PrintPage += new PrintPageEventHandler(this.PrintPage);
           // printCallList.PrintPage += new PrintPageEventHandler(this.PrintCallList);
           //printBingoDocument.QueryPageSettings += new QueryPageSettingsEventHandler(this.QueryPageSettings);
            numCardsToPrint = 0;
            return;
        }


        public void DrawBingoCard(Point pt, Size sz, BingoTable table, System.Drawing.Color tableColor, ref Graphics graphicsObj)
        {
            List<string> data = new List<string>(table.items);
            data.Sort();

            Pen myPen = new Pen(tableColor, 2);
            Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            Rectangle rect = new Rectangle(pt, sz);
            graphicsObj.FillRectangle(whiteBrush, rect);

            int startX = pt.X;
            int startY = pt.Y;
            int endX = sz.Width + pt.X;
            int endY = sz.Height + pt.Y;

            //If free space is enabled, then we have to find the mean and median of rows and cols so we know where to put the free space
            int rowMedian = -1;
            int colMedian = -1;
            bool thisIsAFreeSpace = false;
            if (table.printFreeSpace == true)
            {
                rowMedian = (int)((float)table.rowSize / 2 - 0.5);
                colMedian = (int)((float)table.colSize / 2 - 0.5);
            }

            int squareWidth = sz.Width / table.colSize;
            int squareHeight;

            if (table.printTitle == true)
            {
                squareHeight = sz.Height / (table.rowSize + 1);                         //Adjust the square height if we have a title
                graphicsObj.DrawRectangle(myPen, pt.X, pt.Y, sz.Width, squareHeight);   //Draw the title rectangle

                int titleNumChars = table.titleText.Length;
                int titleOneCharWidth = sz.Width / titleNumChars;                       //Figure out how much space one character of the title occupies

                char[] titleCharArray = table.titleText.ToCharArray();

                int counter = 0;
                foreach (char item in titleCharArray)                                   //For each character in the title, go through the loop
                {
                    float itemFontSize = 150;                                           //Starting font size
                    Font itemFont = new Font(FontFamily.GenericMonospace, itemFontSize);
                    SizeF itemSize = graphicsObj.MeasureString(item.ToString(), itemFont);  //Initial graphic size

                    while (((int)itemSize.Width > titleOneCharWidth) || ((int)itemSize.Height > squareHeight))  //Loop while the size is greater than the box size (titleOneCharWidth)
                    {
                        itemFontSize -= 1;
                        if (itemFontSize <= 0)
                        {
                            itemFontSize = 1;
                            break;
                        } //Avoid badness

                        itemFont = new Font(FontFamily.GenericMonospace, itemFontSize);                         //Decrease font size by 1 and then create new font item
                        itemSize = graphicsObj.MeasureString(item.ToString(), itemFont);                        //Re-measure
                    }   //1) Decrease itemFontSize, re-measure the height and width, if new height and width are bigger than the box then repeat

                    float offset = (titleOneCharWidth - itemSize.Width) / 2;        //The offset is the amount I have to move the start point in order to center the text within the box (titleOneCharWidth)
                    graphicsObj.DrawString(item.ToString(), itemFont, blackBrush, (float)pt.X + offset + counter * titleOneCharWidth, (float)(pt.Y + ((squareHeight - itemSize.Height)/2)));

                    counter += 1;                                                   //Counter keeps track of which titleOneCharWidth box we are in.
                }

                pt.Y = pt.Y + squareHeight;     //Move the Y point down one box size in order to allow for the title

            } //Square height needs to account for the title
            else
            {
                squareHeight = sz.Height / table.rowSize;
            } //Square height doesn't need to account for the title

            for (int rows = 0; rows < table.rowSize; rows++)
            {
                for (int cols = 0; cols < table.colSize; cols++)
                {

                    int xPos = pt.X + cols * squareWidth;
                    int yPos = pt.Y + rows * squareHeight;

                    Rectangle temp = new Rectangle(xPos, yPos, squareWidth, squareHeight);
                    // Rectangle rect2 = new Rectangle(pt.X, pt.Y, squareWidth, squareHeight);
                    graphicsObj.DrawRectangle(myPen, temp);

                    //TextTime!
                    //At this point, we are in a box that has point x, y = (pt.X + cols * squareWidth), (pt.Y + rows * squareHeight)
                    //The box has dimensions of squareWidth and squareHeight.
                    //So, for each word passed to us we must
                    //0) Split on the spaces if a input string is made up entirely of words
                    //1) find the minimum size that will fit in the box
                    //2) Find the vertical and horizontal center
                    //3) Paint the word in the center of the box
                    //This code will take the word list, randomize it, and print the first row * col items

                    Random rand = new Random(table.RandSeed);

                    string itemString = "";
                    int randomIndex = 0;

                    if (data.Count > 0)
                    {
                        randomIndex = rand.Next() % data.Count;
                        itemString = data[randomIndex];
                    }


                    if ((table.printFreeSpace == true) && (rows == rowMedian) && (cols == colMedian))
                    {
                        itemString = table.freeSpaceText;
                        //itemString = itemString.Replace(' ', '\n');
                        thisIsAFreeSpace = true;
                    }

                    int itemFontSize = 15;
                    Font itemFont = new Font(FontFamily.GenericMonospace, itemFontSize);

                    SizeF itemSize = graphicsObj.MeasureString(itemString.ToString(), itemFont);  //Initial graphic size

                    while ((squareWidth < itemSize.Width) || (squareHeight < itemSize.Height))
                    {
                        itemFontSize -= 1;
                        if (itemFontSize <= 0)
                        {
                            itemFontSize = 1;
                            break;
                        } //We must seek to avoid badness in advance. Such is the way of the programmer.

                        itemFont = new Font(FontFamily.GenericMonospace, itemFontSize);
                        itemSize = graphicsObj.MeasureString(itemString.ToString(), itemFont);
                    }

                    //Now, we must find the center of the box so that we can put the text in a proper place
                    //ItemY location is yPos + ((BoxHeight - StringHeight) / 2)
                    //itemX location is xPos + ((BoxWidth - StringWidth) / 2)

                    graphicsObj.DrawString(itemString, itemFont, blackBrush, (float)(xPos + (squareWidth - itemSize.Width) / 2), (float)(yPos + (squareHeight - itemSize.Height) / 2));
                    if ((thisIsAFreeSpace == true))
                    {
                        thisIsAFreeSpace = false;
                    }
                    else if (data.Count > 0)
                    {
                        data.RemoveAt(randomIndex);
                    }
                }
            }
            //graphicsObj.DrawRectangle(myPen, rect);
            //graphicsObj.DrawRectangle(myPen, rect2);
        }



        public void BingoPrintPreview()
        {
            //PrintPreviewDialog dlg = new PrintPreviewDialog();
            printBingoPreviewDialog.Document = printBingoDocument;
            printBingoPreviewDialog.ShowDialog();
        }

        public bool BingoPrintDocument(BingoTable table)
        {
            bingoTable = table;
            printBingoDocument.DefaultPageSettings = PrintPageSettings;  //Tell printDocument what the printer page settings are so when printDialog is called, these page settings will be updated for us to pick up later
           // printCallList.DefaultPageSettings = PrintPageSettings;
            printBingoDialog.Document = printBingoDocument;          //Tell the print dialog what the print document is so it can show settings for it before printing
            numCardsToPrint = bingoTable.numCardsToPrint;           //Tell the fcn how many cards to print

            if (printBingoDialog.ShowDialog() == DialogResult.OK)   //Show the print dialog
            {
                try
                {
                    printCallListOnNextPage = false;
                    printBingoDocument.Print();                         //Call print after the print document is closed with an OK
                   // printCallList.Print();

                }
                catch
                {
                    MessageBox.Show("Unable to print!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
								return (true);
            }
						return (false);
        } //Shows the select printer dialog, then does the print if ok is pushed


        public void BingoSetupPrintPage()
        {
            pageBingoSetupDialog.PageSettings = PrintPageSettings;
            pageBingoSetupDialog.AllowOrientation = true;
            pageBingoSetupDialog.AllowMargins = true;
            pageBingoSetupDialog.ShowDialog();

        }  //Does the page setup


        private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Here we can do a license check to see how much we should randomize the cards
            System.Drawing.Graphics graphicsObj;
            graphicsObj = e.Graphics;
            Rectangle rect = e.MarginBounds;
            Point pt = new Point(rect.X, rect.Y);
            Size sz = new Size(rect.Width, rect.Height);
            Random rand = new Random();

            BingoLicense licenseInfo = new BingoLicense();

            //find the shortest dimension.  That will be our top.
            //Now, rows = cardsPerPage/2, columms = 2.
            //Except, 1 and 2 cards per page are special cases

            if (this.numCardsToPrint > 0)
            {

                if (bingoTable.numCardsPerPage == 1)
                {
                    //Find shortest dimension
                    if (rect.Width <= rect.Height)
                    {
                        sz.Width = sz.Height = rect.Width;

                    }
                    else
                    {
                        sz.Width = sz.Height = rect.Height;
                    }

                    if (this.numCardsToPrint > 0)
                    {
                        PrintCard(pt, sz, bingoTable, Color.Black, ref graphicsObj, licenseInfo);
                    }

                }
                else if (bingoTable.numCardsPerPage == 2)
                {
                    Rectangle tempRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

                    //find shortest dimension that is less than 2x the longer dimension.  Add 10 pixels so we have some space between the tables
                    if (tempRect.Width >= tempRect.Height)
                    {
                        //We are in landscape mode, print out side by side
                        while ((tempRect.Height * 2 + 10) > tempRect.Width)
                        {
                            tempRect.Height -= 1;
                        }

                        //Adjust pt.y so we print in the center of the page
                        pt.Y = pt.Y + ((rect.Height - tempRect.Height) / 2);

                        //Now, the height is 1/2 the width.  Draw the first table.
                        sz.Width = sz.Height = tempRect.Height;


                        if (this.numCardsToPrint > 0)
                        {
                            /*  e.HasMorePages =*/
                            PrintCard(pt, sz, bingoTable, Color.Black, ref graphicsObj, licenseInfo);
                        }
                        //bingoTable.RandSeed += 1;
                        //Add the size of the first card + 10px to pt and draw again
                        if (this.numCardsToPrint > 0)
                        {
                            pt.X = pt.X + sz.Width + 10;
                            /*    e.HasMorePages =*/
                            PrintCard(pt, sz, bingoTable, Color.Black, ref graphicsObj, licenseInfo);
                        }

                    }
                    else
                    {  //We are in portrait mode
                        while ((tempRect.Width * 2 + 10) > tempRect.Height)
                        {
                            tempRect.Width -= 1;
                        }
                        //Adjust pt.x so we print in the center of the page.
                        pt.X = pt.X + ((rect.Width - tempRect.Width) / 2);

                        //Now, the width is 1/2 the height.  Draw the first table.
                        sz.Width = sz.Height = tempRect.Width;

                        /*e.HasMorePages = */
                        if (this.numCardsToPrint > 0)
                        {
                            PrintCard(pt, sz, bingoTable, Color.Black, ref graphicsObj, licenseInfo);
                        }


                        if (this.numCardsToPrint > 0)
                        {

                            pt.Y = pt.Y + sz.Height + 10;
                            /* e.HasMorePages =*/
                            PrintCard(pt, sz, bingoTable, Color.Black, ref graphicsObj, licenseInfo);
                        }
                    }

                }
                else if (bingoTable.numCardsPerPage > 2)
                {
                    Rectangle tempRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                    if (tempRect.Width >= tempRect.Height)
                    {
                        //We are in landscape mode
                        int numCols = bingoTable.numCardsPerPage / 2;
                        tempRect.Width = (rect.Width - 10 * (numCols - 1)) / numCols;

                        tempRect.Height = (rect.Height - 10) / 2;

                        if (tempRect.Height > tempRect.Width)
                        {
                            while (tempRect.Height > tempRect.Width)
                            {
                                tempRect.Height -= 1;
                            }
                            //tempRect.Width = tempRect.Height;
                        }
                        else if (tempRect.Height < tempRect.Width)
                        {
                            while (tempRect.Height < tempRect.Width)
                            {
                                tempRect.Width -= 1;
                            }
                            //tempRect.Height = tempRect.Width;
                        }

                        //Remove a few px becausee we may gain some when we even everything out
                        sz.Height = sz.Width = tempRect.Width - 5;

                        //Adjust the height and column size so they divide evenly into table.row and table.column
                        //This is done because we use integer sizes and we want everything to line up correctly.
                        //Otherwise, there will be badness.
                        int rowSize = bingoTable.rowSize;
                        if (bingoTable.printTitle == true)
                        {
                            rowSize += 1;
                        }
                        int remainder = sz.Height % rowSize;
                        while (remainder != 0)
                        {
                            sz.Height += 1;
                            remainder = sz.Height % rowSize;
                        }

                        int colSize = bingoTable.colSize;
                        remainder = sz.Width % colSize;
                        while (remainder != 0)
                        {
                            sz.Width += 1;
                            remainder = sz.Width % colSize;
                        }
                        //End resize


                        if ((sz.Height <= 0) || (sz.Width <= 0))
                        {
                            MessageBox.Show("Unable to Print.  Bingo card size is less than 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        } //Avoid badness

                        //  for (int card = 0; (card < bingoTable.numCardsPerPage) && (totalCardsToPrint > 0); card++, numCardsToPrint -= 1)
                        //{
                        for (int row = 0; row < 2; row++)
                        {
                            int rowHeight = (rect.Height - 10) / 2;
                            pt.Y = rect.Y + (row * rowHeight) + (10 * row);

                            for (int col = 0; col < numCols; col++)
                            {
                                //bingoTable.RandSeed = rand.Next() % 9999;
                                pt.X = rect.X + (col * tempRect.Width) + (10 * col);
                                if (this.numCardsToPrint > 0)
                                {
                                    PrintCard(pt, sz, bingoTable, Color.Black, ref graphicsObj, licenseInfo);
                                }
                            }
                        }
                    }
                    else
                    {
                        //We are in portrait mode
                        int numRows = bingoTable.numCardsPerPage / 2;
                        tempRect.Height = (rect.Height - 10 * (numRows - 1)) / numRows;  //(10 * numRows - 1) is the gap between each square

                        //Find the largest box that fits.
                        tempRect.Width = (rect.Width - 10) / 2; //10px gap between each square

                        if (tempRect.Width > tempRect.Height)
                        {
                            while (tempRect.Width > tempRect.Height)
                            {
                                tempRect.Width -= 1;
                            }
                            // tempRect.Height = tempRect.Width;
                        }
                        else if (tempRect.Width < tempRect.Height)
                        {
                            while (tempRect.Width < tempRect.Height)
                            {
                                tempRect.Height -= 1;
                            }
                            //tempRect.Width = tempRect.Height;
                        }

                        //Now, tempRect contains the perfect square size
                        sz.Height = sz.Width = tempRect.Width - 3;

                        //Adjust the height and column size so they divide evenly into table.row and table.column
                        //This is done because we use integer sizes and we want everything to line up correctly.
                        //Otherwise, there will be badness.
                        int rowSize = bingoTable.rowSize;
                        if (bingoTable.printTitle == true)
                        {
                            rowSize += 1;
                        }
                        int remainder = sz.Height % rowSize;
                        while (remainder != 0)
                        {
                            sz.Height += 1;
                            remainder = sz.Height % rowSize;
                        }

                        int colSize = bingoTable.colSize;
                        remainder = sz.Width % colSize;
                        while (remainder != 0)
                        {
                            sz.Width += 1;
                            remainder = sz.Width % colSize;
                        }
                        //End resize

                        if ((sz.Height <= 0) || (sz.Width <= 0))
                        {
                            MessageBox.Show("Unable to Print.  Bingo card size is less than 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        } //Avoid badness


                        //for (int card = 0; (card < bingoTable.numCardsPerPage && numCardsToPrint > 0); card++, numCardsToPrint -= 1)
                        //{
                        for (int col = 0; col < 2; col++)
                        {
                            //Center the columns
                            int colWidth = (rect.Width - 10) / 2; //10px gap between each square
                            pt.X = rect.X + (col * colWidth) + (10 * col);
                            for (int row = 0; row < numRows; row++)
                            {
                                // if (e.HasMorePages == true)
                                {
                                    //bingoTable.RandSeed = rand.Next() % 9999;
                                    pt.Y = rect.Y + (row * tempRect.Height) + (10 * row);
                                    if (this.numCardsToPrint > 0)
                                    {
                                        PrintCard(pt, sz, bingoTable, Color.Black, ref graphicsObj, licenseInfo);
                                    }
                                }

                            }

                        }
                    }
                }
            }
            else if (printCallListOnNextPage == true)
            {
                printBingoCallList(pt, sz, bingoTable, Color.Black, ref graphicsObj, licenseInfo, "Hello World!", false);
                printCallListOnNextPage = false;
                e.HasMorePages = false;
                return;
            }
            if (this.numCardsToPrint > 0)
            {
                e.HasMorePages = true;
                return;
            }
            else if (this.numCardsToPrint <= 0)
            {
                if (bingoTable.printCallList == true)
                {
                    e.HasMorePages = true;
                    printCallListOnNextPage = true;
                    return;
                }
                else
                {
                    e.HasMorePages = false;
                    return;
                }
            }

        }


        public void printBingoCallList(Point pt, Size sz, BingoTable table, Color color, ref Graphics graphicsObj, BingoLicense licenseInfo, string Message, bool printMessage)
        {
            Font titleFont = new Font(FontFamily.GenericMonospace, 14, FontStyle.Bold);
            Font itemFont = new Font(FontFamily.GenericMonospace, 12);
            Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            string wordList = "";

            foreach (string item in table.items)
            {
                wordList += item + "\n";
            }

            if (printMessage == true)
            {
                wordList += "\n\n" + Message + "\n";
            }

            //Draw title
            string listTitle = "Call List";

            SizeF itemSize = graphicsObj.MeasureString(listTitle.ToString(), titleFont);
            Point titlePoint = new Point(pt.X + (int)((sz.Width - itemSize.Width) / 2), pt.Y);
            graphicsObj.DrawString(listTitle, titleFont, blackBrush, titlePoint);

            pt.Y += (int)(itemSize.Height + 0.5);

            //Draw words
            graphicsObj.DrawString(wordList, itemFont, blackBrush, pt);
            return;
        }



        public void PrintCard(Point pt, Size sz, BingoTable table, Color color, ref Graphics graphicsObj, BingoLicense licenseInfo)
        {



            if (this.numCardsToPrint > 0)
            {
                if (licenseInfo.isLicensed == true)
                {
                    Random rand = new Random();
                    bingoTable.RandSeed = rand.Next() % 9999;
                }
                else
                {
                    bingoTable.RandSeed += 1;
                }

                DrawBingoCard(pt, sz, bingoTable, Color.Black, ref graphicsObj);
                //return (true);
            }
            this.numCardsToPrint -= 1;
        }

    }

    class BingoFileFuncs
    {
        List<string> fileList;

        public BingoFileFuncs()
        {
            fileList = new List<string>();

        }

        public BingoWordFile openFile(string filePath)
        {
            
            BingoWordFile file = new BingoWordFile(filePath);
            int printTitle = 0;
            int printFreeSpace = 0;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (DbConnection configdb = new SQLiteConnection("Data Source=" + file.filePath))
                {
                    using (DbCommand cmd = configdb.CreateCommand())
                    {

                        configdb.Open();

                        cmd.CommandText = "SELECT * FROM 'info'";
                        try
                        {
                            using (DbDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    try
                                    {
                                        file.cardTitleText = reader["cardtitletext"].ToString();
                                    }
                                    catch
                                    {
                                        file.cardTitleText = "";
                                    }
                                    try
                                    {
                                        file.cardFreeSpaceText = reader["cardfreespacetext"].ToString();
                                    }
                                    catch
                                    {
                                        file.cardFreeSpaceText = "";
                                    }
                                    try
                                    {
                                        file.cardRowSize = int.Parse(reader["cardrowsize"].ToString());
                                    }
                                    catch
                                    {
                                        file.cardRowSize = 5;
                                    }
                                    try
                                    {
                                        file.cardColSize = int.Parse(reader["cardcolsize"].ToString());
                                    }
                                    catch
                                    {
                                        file.cardColSize = 5;
                                    }
                                    try
                                    {

                                        file.numCardsToPrint = int.Parse(reader["numcardstoprint"].ToString());
                                    }
                                    catch
                                    {
                                        file.numCardsToPrint = 1;
                                    }
                                    try
                                    {
                                        file.numCardsPerPage = int.Parse(reader["numcardsperpage"].ToString());
                                    }
                                    catch
                                    {
                                        file.numCardsPerPage = 1;
                                    }
                                    try
                                    {
                                        printTitle = int.Parse(reader["printTitle"].ToString());
                                    }
                                    catch
                                    {
                                        printTitle = 0;
                                    }

                                    if (printTitle >= 1)
                                    {
                                        file.printTitle = true;
                                    }
                                    else
                                    {
                                        file.printTitle = false;
                                    }

                                    try
                                    {
                                        printFreeSpace = int.Parse(reader["printFreeSpace"].ToString());
                                    }
                                    catch
                                    {
                                        printFreeSpace = 0;
                                    }

                                    if (printFreeSpace >= 1)
                                    {
                                        file.printFreeSpace = true;
                                    }
                                    else
                                    {
                                        file.printFreeSpace = false;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            file.cardColSize = file.cardRowSize = 5;  //Set default values so we don't get divide by 0
                        }


                        cmd.CommandText = "SELECT * FROM 'wordlist'";
                        try
                        {
                            using (DbDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    try
                                    {
                                        file.wordList.Add(reader["word"].ToString());
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }


                        configdb.Close();
                    }



                }
            }
            catch
            {

            }

            finally
            {
                Cursor.Current = Cursors.Default;
                

            }
            return (file);
        }


        public bool writeFile(BingoWordFile file) {

            if (file.filePath.EndsWith(".bwf") == false)
            {
                file.filePath += ".bwf";
            } //Bingo word file

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (DbConnection configdb = new SQLiteConnection("Data Source=" + file.filePath))
                {
                    using (DbCommand cmd = configdb.CreateCommand())
                    {
                        //open the connection
                        configdb.Open();

                        try
                        {
                            cmd.CommandText = "DROP TABLE info";
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {

                        }
                        try
                        {
                            cmd.CommandText = "DROP TABLE wordlist";
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {

                        }


                        try
                        {
                            int freeSpacePrint = file.printFreeSpaceToInt();
                            int titlePrint = file.printTitleToInt();

                            cmd.CommandText = "CREATE TABLE info (cardtitletext TEXT, cardfreespacetext TEXT, cardrowsize TEXT, cardcolsize TEXT, numcardstoprint TEXT, numcardsperpage TEXT, printTitle TEXT, printFreeSpace TEXT)";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "INSERT into info VALUES ('" + file.cardTitleText + "','" + file.cardFreeSpaceText + "','" + file.cardRowSize.ToString() + "', '" + file.cardColSize.ToString() + "', '" + file.numCardsToPrint.ToString() + "', '" + file.numCardsPerPage.ToString() + "', '" + titlePrint.ToString() + "', '" + freeSpacePrint.ToString() + "')";
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }

                        try
                        {
                            cmd.CommandText = "CREATE TABLE wordlist (word TEXT)";
                            cmd.ExecuteNonQuery();

                            foreach (string item in file.wordList)
                            {
                                cmd.CommandText = "INSERT into wordlist VALUES ('" + item + "')";
                                cmd.ExecuteNonQuery();
                            }

                        }

                        catch
                        {

                        }

                        try
                        {
                            configdb.Close();
                        }
                        catch
                        {
                        }
                    }

                }
            }
            catch
            {


            }

            finally
            {

                Cursor.Current = Cursors.Default;
            }

            return (true);
        }



        public bool FileExists(string file)
        {
            if (File.Exists(file))
            {
                return (true);
            }
            return (false);
        }
    }

    class BingoWordFile
    {
        public string filePath;
        public List<string> wordList;
        public string cardTitleText;
        public string cardFreeSpaceText;
        public int cardRowSize;
        public int cardColSize;
        public int numCardsToPrint;
        public int numCardsPerPage;
        public bool printTitle;
        public bool printFreeSpace;

        public BingoWordFile(string file)
        {
            this.wordList = new List<string>();
            this.filePath = file;
        }

        public int printTitleToInt()
        {
            if (printTitle == true)
            {
                return (1);
            }
            return (0);
        }

        public int printFreeSpaceToInt()
        {
            if (printFreeSpace == true)
            {
                return (1);
            }
            return (0);
        }

        public BingoWordFile(string filePath, List<string> wordList, string cardTitleText, string cardFreeSpaceText, int cardRowSize, int cardColSize, int numCardsToPrint, int numCardsPerPage, bool printTitle, bool printFreeSpace)
        {
            this.wordList = new List<string>(wordList);
            this.filePath = filePath;
            this.cardTitleText = cardTitleText;
            this.cardFreeSpaceText = cardFreeSpaceText;
            this.cardRowSize = cardRowSize;
            this.cardColSize = cardColSize;
            this.numCardsPerPage = numCardsPerPage;
            this.numCardsToPrint = numCardsToPrint;
            this.printTitle = printTitle;
            this.printFreeSpace = printFreeSpace;

        }


        public BingoWordFile(string filePath, List<string> wordList, string cardTitleText, string cardFreeSpaceText, int cardRowSize, int cardColSize, int numCardsToPrint, int numCardsPerPage, int printTitle, int printFreeSpace)
        {
            this.wordList = new List<string>(wordList);
            this.filePath = filePath;
            this.cardTitleText = cardTitleText;
            this.cardFreeSpaceText = cardFreeSpaceText;
            this.cardRowSize = cardRowSize;
            this.cardColSize = cardColSize;
            this.numCardsPerPage = numCardsPerPage;
            this.numCardsToPrint = numCardsToPrint;
            if (printTitle >= 1)
            {
                this.printTitle = true;
            }
            else
            {
                this.printTitle = false;
            }

            if (printFreeSpace >= 1)
            {
                this.printFreeSpace = true;
            }
            else
            {
                this.printFreeSpace = false;
            }
        }

    }
}
