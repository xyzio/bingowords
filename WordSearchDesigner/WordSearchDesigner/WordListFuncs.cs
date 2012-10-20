using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System.IO;

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

            words = new List<string>("Algeria:Angola:Benin:Botswana:Burkina Faso:Burundi:Cameroon:Cape Verde:Central African Rep:Chad:Congo:Zaire:Djibouti:Egypt:Equatorial Guinea:Eritrea:Ethiopia:Gabon:Gambia:Ghana:Guinea Bissau:Guinea:Ivory Coast:Kenya:Lesotho:Liberia:Libya:Madagascar:Malawi:Mali:Mauritania:Mauritius:Morocco:Mozambique:Namibia:Niger:Nigeria:Reunion:Rwanda:São Tomé and Principe:Senegal:Seychelles:Sierra Leone:Somalia:South Africa:Sudan:Swaziland:Tanzania:Togo:Tunisia:Uganda:Zambia:Zanzibar:Zimbabwe".Split(':'));
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

        public Category(string name)
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


namespace WordSearchDesigner
{
    class WordListFuncs
    {
    }

		class BingoLicense {
			private string code = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123!@#";
			private string secret = "SAFBUCMDSEKF!#%";
			private string secret2 = "fj*U#%IJifJ:23";
			public bool isLicensed;
			//public string name;
			private string license;
			public string licenseText;
			
			//Bingo card
			public int maxItems = 25;
			public int maxNumCardsToPrint = 15;

			//Word search
			public int gridSize = 15;
			public int maxWordSearchCardsToPrint = 5;
			public int maxWordSearchWords = 15;


			public void readLicenceFile() {

				license = "";
				licenseText = "This copy of Word Search Designer is not licensed.";
				isLicensed = false;


				string licensePath = Application.StartupPath;
				licensePath = Path.Combine(licensePath, "license.txt");

				if (File.Exists(licensePath)) {

					FileStream file = new FileStream(licensePath, FileMode.Open, FileAccess.Read);
					StreamReader sr = new StreamReader(file);

					while (sr.EndOfStream != true) {
						string line = sr.ReadLine();
						if (line == null) {
							continue;
						}
						line = line.ToUpper();
						if (line.Contains("LICENSE: ")) {
							Regex licenseRegex = new Regex("LICENSE: (.+)");
							string[] results = licenseRegex.Split(line);

							foreach (string item in results) {
								{
									if (item != "") {
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

					if ((this.license != null)) {
						if (this.readLicence() == true) {
							licenseText = "This copy of Word Search Designer is licensed.\n\nLicense: " + license;
							isLicensed = true;
						}

						else {

							license = "";
							isLicensed = false;
							licenseText = "This copy of Word Search Designer is not licensed.";
						}

						return;
					}
				}

				license = "";
				isLicensed = false;
				licenseText = "This copy of Word Search Designer is not licensed.";

			}

			public BingoLicense() {
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

			public bool readLicence() {
				return (Decrypt(license));
			}

			private bool Decrypt(string licence) {
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
				for (int i = 0; i < returnChar.Length; i++) {
					if (returnString.Length >= 8) {
						break;
					}
					if (((returnChar[i] >= 48) && (returnChar[i] <= 57)) || ((returnChar[i] >= 65) && (returnChar[i] <= 90)) || ((returnChar[i] >= 97) && (returnChar[i] <= 122))) {
						returnString += returnChar[i].ToString().ToUpper();
					}
				}

				if (returnString.Length < 8) {
					//Pad the rest with 0
					while (returnString.Length < 8) {
						returnString += "0";
					}
				}

				try {
					licence = splitLicense[1] + splitLicense[2];
				}
				catch {
					return (false);
				}

				if (licence == returnString) {
					return (true);
				}

				return (false);
			}

		}

		class BingoLinks {

            public string mainSiteLink = "http://xyzio.com/BingoWordsWebsite/Default.aspx";
            public string purchaseSiteLink = "http://xyzio.com/BingoWordsWebsite/Purchase/Default.aspx";

			public BingoLinks() {

				return;
			}

		}



    public class WordListData
    {
        public List<string> words = new List<string>();
        public bool printTitle = false;
        public string titleText = "Word Search";
        public string titleTextFont = "Verdana";
        public int titleFontSize = 24;
        public int titleTextBuffer = 10; //Buffer size in px
        public int gridSize = 15;
        public int cardsPerPage = 1;
        public int numCardsToPrint = 1;
        public bool printGrid = true;
        public bool printSolution = true;
        public bool printWordList = true;
        public bool showSolution = true;
        public string filePath = null;
        public AllowedDirections allowedDirections = new AllowedDirections();
        public WordSearchFileFuncs fileFuncs = new WordSearchFileFuncs();
        puzzleGeneratorClass puzzleGenerator;
        public puzzleData puzzle = new puzzleData();

        public bool openFile(string fileName)
        {
            this.filePath = fileName;

            if (this.fileFuncs.FileExists(fileName) == false)
            {
                return (false);
            }

            puzzleDataFile fileContents = this.fileFuncs.readFile(fileName);

            this.words = new List<string>(fileContents.words);
            this.printTitle = fileContents.printTitle;
            this.titleText = fileContents.titleText;
            this.titleTextFont = fileContents.titleTextFont;
            this.titleFontSize = fileContents.titleFontSize;
            this.titleTextBuffer = fileContents.titleTextBuffer;
            this.gridSize = fileContents.gridSize;
            this.cardsPerPage = fileContents.cardsPerPage;
            this.numCardsToPrint = fileContents.numCardsToPrint;
            this.printGrid = fileContents.printGrid;
            this.printSolution = fileContents.printSolution;
            this.printWordList = fileContents.printWordList;
            this.showSolution = fileContents.showSolution;
            this.filePath = fileContents.filePath;
            this.allowedDirections = new AllowedDirections(fileContents.AllowedDirections);

            puzzleGenerator = new puzzleGeneratorClass(gridSize, words, this.allowedDirections);
            puzzle = new puzzleData();
            puzzle = puzzleGenerator.generatePuzzle();

            // public List<string> unableToPlace = new List<string>();
            //public AllowedDirections allowedDirections = new AllowedDirections();

            return (true);
        } //Constructor when opening a file

        public WordListData(List<string> inWords)
        {
            this.words = new List<string>(inWords);

            regeneratePuzzle();

        }
        public WordListData(int gridSize)
        {
					this.gridSize = gridSize;
          regeneratePuzzle();
        }

        public void regeneratePuzzle()
        {
            puzzleGenerator = new puzzleGeneratorClass(gridSize, words, this.allowedDirections);
            puzzle = puzzleGenerator.generatePuzzle();
        }


    }

    public class AllowedDirections
    {
        public bool vertical = true;
        public bool Diagonal = true;
        public bool Horizontal = true;
        public bool Backwards = true;

        public AllowedDirections(string directions)
        {
            convertFromString(directions);
        }

        public AllowedDirections()
        {

        }

        public string convertToString() {

            /* Use a binary value to store the info 
             * 1000 -> Vertical   -> 8
             * 0100 -> Diagonal   -> 4
             * 0010 -> Horizontal -> 2
             * 0001 -> Backwards  -> 1
             * 
             */

            int directions = 0;

            if (this.vertical == true)
            {
                directions |= 8;
            }
            if (this.Diagonal == true)
            {
                directions |= 4;
            }
            if (this.Horizontal == true)
            {
                directions |= 2;
            }
            if (this.Backwards == true)
            {
                directions |= 1;
            }

            return (directions.ToString());

        }

        public void convertFromString(string str)
        {
            //AllowedDirections directions = new AllowedDirections();


            int data = 0;

            try
            {
                data = Int32.Parse(str);
            }
            catch
            {
                this.vertical = this.Diagonal = this.Horizontal = this.Backwards = true;
                return;
            } //Fail gracefully

            this.vertical = this.Diagonal = this.Horizontal = this.Backwards = false;


            if ((data & 8) == 8)
            {
                this.vertical = true;
            }
            if ((data & 4) == 4)
            {
                this.Diagonal = true;
            }
            if ((data & 2) == 2)
            {
                this.Horizontal = true;
            }
            if ((data & 1) == 1)
            {
                this.Backwards = true;
            }

        }

    }

    public class puzzleData
    {
        public char[,] grid;
        public int intersectionCount;
        public List<string> unableToPlace = new List<string>();
        public static List<string> words = new List<string>();
        public static int gridSize;

        public puzzleData()
        {

        }

        public puzzleData(char[,] inGrid, int inIntersectionCount, List<string> inUnableToPlace)
        {
            this.grid = inGrid;
            this.intersectionCount = inIntersectionCount;
            this.unableToPlace = inUnableToPlace;

            return;
        }

        public puzzleData(puzzleData data)
        {
            this.grid = data.grid;
            this.intersectionCount = data.intersectionCount;
            this.unableToPlace = data.unableToPlace;
        }

        public static void setGridSize(int size)
        {
            gridSize = size;
        }

        public static void addWords(List<string> wordList)
        {
            words = wordList;
        }
    }

    class puzzleGeneratorClass
    {

        List<string> words;
        int gridSize;
        AllowedDirections directionsAllowed;

        public puzzleGeneratorClass(int gridSize, List<string> words, AllowedDirections allowedDirections)
        {

            this.gridSize = gridSize;
            this.words = new List<string>(words);
            cleanUpWords();
            puzzleData.addWords(words);
            puzzleData.setGridSize(gridSize);
            this.directionsAllowed = allowedDirections;

        }

        public puzzleData generatePuzzle()
        {
            StringLengthComparer sortByWordSize = new StringLengthComparer();
            words.Sort(sortByWordSize);

            List<puzzleData> puzzleList = new List<puzzleData>();
            puzzleData puzzle = new puzzleData();
            puzzleData finalPuzzle = new puzzleData();

            for (int i = 0; i < 1000; i++)
            {
                puzzle.intersectionCount = 0;
                puzzle.unableToPlace.Clear();

                puzzle.grid = createWordSearchPuzzle(puzzleData.gridSize, puzzleData.words, ref puzzle.unableToPlace, ref puzzle.intersectionCount, directionsAllowed);
                puzzleList.Add(new puzzleData(puzzle));
            }

            int tempIntersectionCount = -1;
            int unableToPlaceCount = 100000;
            //Find the maximum intersection count
            foreach (puzzleData data in puzzleList)
            {
                if (data.intersectionCount > tempIntersectionCount)
                {
                    finalPuzzle = new puzzleData(data);
                    tempIntersectionCount = data.intersectionCount;
                } //maximize intersection count, minimize unable to place
                if (data.unableToPlace.Count < unableToPlaceCount)
                {
                    finalPuzzle = new puzzleData(data);
                    unableToPlaceCount = data.unableToPlace.Count;
                }
            }

            return (finalPuzzle);
        }

        private void setDirections(ref Dictionary<string, int> direction_x, ref Dictionary<string, int> direction_y, ref List<string> directions, AllowedDirections allowedDirections)
        {
            direction_x.Add("E", 1);
            direction_x.Add("S", 0);
            direction_x.Add("W", -1);
            direction_x.Add("N", 0);
            direction_x.Add("NE", 1);
            direction_x.Add("SE", 1);
            direction_x.Add("SW", -1);
            direction_x.Add("NW", -1);


            direction_y.Add("E", 0);
            direction_y.Add("S", -1);
            direction_y.Add("W", 0);
            direction_y.Add("N", 1);
            direction_y.Add("NE", 1);
            direction_y.Add("SE", -1);
            direction_y.Add("SW", -1);
            direction_y.Add("NW", 1);


            //To restrict directions, remove them from the directions hash below
            directions.Clear();
            if (allowedDirections.Horizontal == true)
            {
                directions.Add("E");
                if (allowedDirections.Backwards == true)
                {
                    directions.Add("W");
                }
            }

            if (allowedDirections.vertical == true)
            {
                directions.Add("N");

                if (allowedDirections.Backwards == true)
                {

                    directions.Add("S");
                }
            }

            if (allowedDirections.Diagonal == true)
            {
                directions.Add("NE");
                directions.Add("SE");

                if (allowedDirections.Backwards == true)
                {
                    directions.Add("SW");
                    directions.Add("NW");
                }
            }

            return;
        }

				private char[,] createWordSearchPuzzle(int size, List<string> wordList, ref List<string> noMatches, ref int intersectionCount, AllowedDirections allowedDirections) {

					Random rand = new Random();  //Use this later to randomize puzzles

					Dictionary<string, int> direction_y = new Dictionary<string, int>();
					Dictionary<string, int> direction_x = new Dictionary<string, int>();
					List<string> directions = new List<string>();

					setDirections(ref direction_x, ref direction_y, ref directions, allowedDirections);

					//Here we will create the puzzle
					char[,] grid = new char[size, size];
					clearGrid(grid, size); //Clear grid

					char[,] tempGrid = new char[size, size];
					clearGrid(tempGrid, size); //Clear grid


					foreach (string temp in wordList) {
						// string item = temp.Replace(" ", "");


						StringBuilder sb = new StringBuilder();
						for (int i = 0; i < temp.Length; i++) {
							if (char.IsLetter(temp[i])) {
								sb.Append(temp[i]);
							}
						}

						string str = sb.ToString();
						char[] word = str.ToCharArray();
						if (word.Length <= 0) {
							continue;
						}


						bool success = false;
						const int maxTries = 100;
						int counter = 0;

						while ((success == false) && (counter < maxTries)) {

							int x = rand.Next() % size;
							int y = rand.Next() % size;

							if (directions.Count <= 0) {
								return (grid);
							}
							string dir_xy = directions[rand.Next() % directions.Count];
							//string dir_y = directions[rand.Next() % directions.Count];

							int currentX = x;
							int currentY = y;

							int index;
							for (index = 0; index < word.Length; index++) {
								if ((grid[currentX, currentY] == ' ') || (grid[currentX, currentY] == word[index])) {
									if (grid[currentX, currentY] == word[index]) {
										intersectionCount += 1;
									}

									tempGrid[currentX, currentY] = word[index];

									currentX = x + (index + 1) * direction_x[dir_xy];  //Add 1 to index because when index = 0, current index doesn't increment on the first loop which overwrites the first letter of the word.  The price I pay for elegance :(
									currentY = y + (index + 1) * direction_y[dir_xy];

									if ((checkGridBoundry(currentX, currentY, size)) == false) {
										//It didn't work!

										clearGrid(tempGrid, size);
										counter += 1;
										break;                      //Try again
									}
								}
								else {
									//Grid is not blank and it doesn't have a matching word
									clearGrid(tempGrid, size);
									counter += 1;
									break;
								}
							}
							if (index == (word.Length)) {
								success = true;
							}
						}
						if (success == true) {
							//success = false;
							for (int i = 0; i < size; i++) {
								for (int j = 0; j < size; j++) {
									if (grid[i, j] == ' ') {
										grid[i, j] = tempGrid[i, j];
									}
								}
							}
						}
						else {
							noMatches.Add(str);
						}
						clearGrid(tempGrid, size);
					}
					//Do this at the end before displaying.  That way we can show the solution.
					//populateGrid(grid, size);
					return (grid);
				}

        private bool checkGridBoundry(int currentX, int currentY, int size)
        {
            if ((currentX >= size) || (currentX < 0) || (currentY >= size) || (currentY < 0))
            {
                return (false);

            }
            return (true);
        }

        private void cleanUpWords()
        {
            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].ToLower();
            }
        }

        private void clearGrid(char[,] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = ' ';
                }
            }
        }
    }

    public class StringLengthComparer : IComparer<string>
    {

        public int Compare(string s1, string s2)
        {

            if (s1.Length > s2.Length)
            {
                return -1;
            }
            else if (s1.Length < s2.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }


    class PrintWordList
    {

        PrintDocument printDocument;
        PrintPreviewDialog printPreviewDialog;
        PrintDialog printDialog;
        PageSetupDialog pageSetupDialog;
        PageSettings pageSettings;
        WordListData wordListData;
        int numPagesToPrint;
        bool solutionPrinted;
        bool printSolution;
        //  bool printSolutionOnNextPage;


        public PrintWordList()
        {
            printDocument = new PrintDocument();
            printPreviewDialog = new PrintPreviewDialog();
            printDialog = new PrintDialog();
            pageSetupDialog = new PageSetupDialog();
            pageSettings = new PageSettings();
            printDocument.PrintPage += new PrintPageEventHandler(this.PrintPage);
            return;
        }



        public bool PrintWordSearchDocument(ref WordListData dataIn)
        {
            this.wordListData = dataIn;
            this.numPagesToPrint = wordListData.numCardsToPrint;
            this.printSolution = wordListData.printSolution;
            // this.printSolutionOnNextPage = true;

            printDocument.DefaultPageSettings = pageSettings;
            // printCallList.DefaultPageSettings = PrintPageSettings;
            printDialog.Document = printDocument;          //Tell the print dialog what the print document is so it can show settings for it before printing
						try {
							if (printDialog.ShowDialog() == DialogResult.OK)   //Show the print dialog
            {
								try {
									printDocument.Print();                         //Call print after the print document is closed with an OK
								}
								catch {
									MessageBox.Show("Unable to print!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								}
								return (true);
							}
						}
						catch {
						}
            return (false);
        } //Shows the select printer dialog, then does the print if ok is pushed

        private bool printSingleWordSearchPage(bool showSolution, Size sz, ref System.Drawing.Graphics graphicsObj, Point pt)
        {
            Size titleSize = new Size();
            Size searchGridSize = new Size();
            Size wordsToFindSize = new Size();
            getTitleSize(ref titleSize, this.wordListData, sz, ref graphicsObj);
            //  titleSize.Height = titleSize.Height + wordListData.titleTextBuffer; //Cheat :)
            getWordsToFindSize(ref wordsToFindSize, this.wordListData, sz, ref graphicsObj);
            bool result = getSearchGridSize(ref titleSize, ref wordsToFindSize, ref searchGridSize, this.wordListData, sz, ref graphicsObj);

            drawTitle(pt, sz, this.wordListData, Color.Black, ref graphicsObj);
            pt.Y = pt.Y + titleSize.Height;// +wordListData.titleTextBuffer; //Cheat :)
            Point gridPt = new Point(pt.X, pt.Y);
            gridPt.X = gridPt.X + (sz.Width - searchGridSize.Width) / 2;
            drawWordList(gridPt, searchGridSize, this.wordListData, Color.Black, false, ref graphicsObj);
            pt.Y = pt.Y + searchGridSize.Height;
            drawWordsToFind(pt, sz, this.wordListData, Color.Black, ref graphicsObj);


            return (true);
        }

        private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            System.Drawing.Graphics graphicsObj;
            graphicsObj = e.Graphics;
            Rectangle rect = e.MarginBounds;
            Point pt = new Point(rect.X, rect.Y);
            Size sz = new Size(rect.Width, rect.Height);

            if (e.PageSettings.Landscape == true)
            {
                e.PageSettings.Landscape = false;
            } //Print in portrait mode only


            //How to print.
            //1: Find the title size
            //2: Find the words size
            //3: Print the grid in the remaining space
            if (this.numPagesToPrint > 0)
            {

                //printSingleWordSearchPage(bool showSolution, Size sz, ref System.Drawing.Graphics graphicsObj)
                printSingleWordSearchPage(false, sz, ref graphicsObj, pt);


                this.numPagesToPrint -= 1;

                e.HasMorePages = true;
                return;

            }
            else if (this.printSolution == true)
            {
                Size titleSize = new Size();
                Size searchGridSize = new Size();
                Size wordsToFindSize = new Size();

                getTitleSize(ref titleSize, this.wordListData, sz, ref graphicsObj);
                //  titleSize.Height = titleSize.Height + wordListData.titleTextBuffer; //Cheat :)
                getWordsToFindSize(ref wordsToFindSize, this.wordListData, sz, ref graphicsObj);
                bool result = getSearchGridSize(ref titleSize, ref wordsToFindSize, ref searchGridSize, this.wordListData, sz, ref graphicsObj);

                drawTitle(pt, sz, this.wordListData, Color.Black, ref graphicsObj);
                pt.Y = pt.Y + titleSize.Height;// +wordListData.titleTextBuffer; //Cheat :)
                Point gridPt = new Point(pt.X, pt.Y);
                gridPt.X = gridPt.X + (sz.Width - searchGridSize.Width) / 2;
                drawWordList(gridPt, searchGridSize, this.wordListData, Color.Black, true, ref graphicsObj);
                pt.Y = pt.Y + searchGridSize.Height;
                drawWordsToFind(pt, sz, this.wordListData, Color.Black, ref graphicsObj);
                //Print solution
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = false;
            }
            //Print solution page if needed
            //1) Go to next page
            //2) Reprint above with solution enabled
        }

        private void drawTitle(Point pt, Size sz, WordListData data, Color color, ref Graphics graphicsObj)
        {
            Font itemFont = new Font(data.titleTextFont, data.titleFontSize, FontStyle.Bold);
            Brush blackBrush = new System.Drawing.SolidBrush(color);

            graphicsObj.DrawString(data.titleText + "\n", itemFont, blackBrush, pt);

        }

        private void drawWordsToFind(Point pt, Size sz, WordListData data, Color color, ref Graphics graphicsObj)
        {

            Brush blackBrush = new System.Drawing.SolidBrush(color);

            //Lets print the words out in 3 columns
            int colSize = (int)((float)sz.Width / 3);
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            List<string> column3 = new List<string>();

            for (int i = 0; i < data.words.Count; i++)
            {
                if (0 == (i % 3))
                {
                    column3.Add(data.words[i]);
                }
                else if (2 == (i % 3))
                {
                    column2.Add(data.words[i]);
                }
                else if (1 == (i % 3))
                {
                    column1.Add(data.words[i]);
                }
            }
            //Find title size

            //Draw word list title
            Font itemFont = new Font(FontFamily.GenericMonospace, 14);

            graphicsObj.DrawString("Word List\n", itemFont, blackBrush, pt);

            SizeF size = graphicsObj.MeasureString("Word List\n", itemFont);

            pt.Y = pt.Y + (int)size.Height;


            //Draw words
            //Column 1
            itemFont = new Font(FontFamily.GenericMonospace, 12);

            string wordColumn = "";

            for (int i = 0; i < column1.Count; i++)
            {
                wordColumn = wordColumn + column1[i] + "\n";
            }

            graphicsObj.DrawString(wordColumn, itemFont, blackBrush, pt);

            //Col 2 offset
            size = graphicsObj.MeasureString(wordColumn, itemFont);
            pt.X = pt.X + colSize;

            //Column 2
            wordColumn = "";

            for (int i = 0; i < column2.Count; i++)
            {
                wordColumn = wordColumn + column2[i] + "\n";
            }
            graphicsObj.DrawString(wordColumn, itemFont, blackBrush, pt);


            //Col 3 offset
            size = graphicsObj.MeasureString(wordColumn, itemFont);
            pt.X = pt.X + colSize;

            //Column 3
            wordColumn = "";

            for (int i = 0; i < column3.Count; i++)
            {
                wordColumn = wordColumn + column3[i] + "\n";
            }

            graphicsObj.DrawString(wordColumn, itemFont, blackBrush, pt);
        }

        private bool getSearchGridSize(ref Size titleSize, ref Size wordsToFindSize, ref Size searchGridSize, WordListData wordListData, Size sz, ref Graphics graphicsObj)
        {
            //grid size is going to be page size - titleSize - wordsToFindSize

            Size tempGridSize = new Size();
            tempGridSize.Height = sz.Height - titleSize.Height - wordsToFindSize.Height;
            tempGridSize.Width = sz.Width;// -titleSize.Width - wordsToFindSize.Width;

            if ((tempGridSize.Height < 0) || (tempGridSize.Width < 0))
            {
                return (false);
            } //Check for negative

            if (tempGridSize.Width < tempGridSize.Height)
            {
                searchGridSize.Height = searchGridSize.Width = tempGridSize.Width;
                return (true);
            }  //Width is smaller than height
            else
            {
                searchGridSize.Width = searchGridSize.Height = tempGridSize.Height;
                return (true);
            }  //Height is smaller than width
        }

        private void getWordsToFindSize(ref Size wordsToFindSize, WordListData data, Size sz, ref Graphics graphicsObj)
        {
            //Lets print the words out in 3 columns
            int colSize = (int)((float)sz.Width / 3);
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            List<string> column3 = new List<string>();

            for (int i = 0; i < data.words.Count; i++)
            {
                if (0 == (i % 3))
                {
                    column3.Add(data.words[i]);
                }
                else if (2 == (i % 3))
                {
                    column2.Add(data.words[i]);
                }
                else if (1 == (i % 3))
                {
                    column1.Add(data.words[i]);
                }
            }


            //Word list printout looks like this:
            //Word List: (bold and size 14)
            //<CR>
            //Col1      Col 2          Col3 (Not bold and size 12)

            //Find title size
            Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            Font itemFont = new Font(FontFamily.GenericMonospace, 14);

            SizeF titleSize = graphicsObj.MeasureString("Word List\n", itemFont);

            //Find wordlist size
            itemFont = new Font(FontFamily.GenericMonospace, 12);
            string wordColumn = "";

            for (int i = 0; i < column1.Count; i++)
            {
                wordColumn = wordColumn + "\n";
            }

            SizeF columnSize = graphicsObj.MeasureString(wordColumn, itemFont);

            wordsToFindSize.Height = (int)(titleSize.Height + columnSize.Height);
            wordsToFindSize.Width = (int)(titleSize.Width + titleSize.Height);

        }

        private void getTitleSize(ref Size titleSize, WordListData data, Size sz, ref Graphics graphicsObj)
        {
            Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            Font itemFont = new Font(data.titleTextFont, data.titleFontSize);
            string title = data.titleText;
            SizeF size = graphicsObj.MeasureString(title, itemFont);

            while ((int)size.Width > (int)sz.Width)
            {
                data.titleFontSize -= 1;
                itemFont = new Font(FontFamily.GenericMonospace, data.titleFontSize);
                size = graphicsObj.MeasureString(title, itemFont);
            }

            titleSize.Width = (int)size.Width;
            titleSize.Height = (int)size.Height + data.titleTextBuffer;

        }

        private Font resizeString(string data, Size sz, Font seedFont, ref Graphics graphicsObj, ref Size stringSize)
        {
            float itemFontSize = seedFont.Size;                                           //Starting font size
            Font itemFont = new Font(seedFont.FontFamily, seedFont.Size);

            SizeF dataSizeF = graphicsObj.MeasureString(data, seedFont);
            stringSize = new Size((int)dataSizeF.Width, (int)dataSizeF.Height);
            while ((stringSize.Width > sz.Width) && (stringSize.Height > sz.Height))
            {
                itemFontSize -= 1;
                if (itemFontSize <= 1)
                {
                    itemFont = new Font(seedFont.FontFamily, 1);
                    //itemFont.Size = 0;
                    break;
                }
                itemFont = new Font(seedFont.FontFamily, itemFontSize);
                dataSizeF = graphicsObj.MeasureString(data, itemFont);
                stringSize = new Size((int)dataSizeF.Width, (int)dataSizeF.Height);
            }

            return (itemFont);

        }


        public void drawWordList(Point pt, Size sz, WordListData data, System.Drawing.Color color, bool showSolution, ref Graphics graphicsObj)
        {
            // List<string> data = new List<string>(table.items);
            //data.Sort();

            Pen myPen = new Pen(color, 1);
            Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            Random rand = new Random(0);
            char[] lettersByFrequency = { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'b', 'b', 'c', 'c', 'c', 'd', 'd', 'd', 'd', 'd', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'f', 'f', 'f', 'g', 'g', 'g', 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'i', 'i', 'i', 'i', 'i', 'i', 'i', 'j', 'k', 'l', 'l', 'l', 'l', 'l', 'm', 'm', 'm', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'p', 'p', 'q', 'r', 'r', 'r', 'r', 'r', 'r', 's', 's', 's', 's', 's', 's', 's', 't', 't', 't', 't', 't', 't', 't', 't', 't', 't', 'u', 'u', 'u', 'v', 'w', 'w', 'w', 'x', 'y', 'y', 'z' };
            //data.grid
            Rectangle rect = new Rectangle(pt, sz);
            graphicsObj.FillRectangle(whiteBrush, rect); //Paint background

            Size squareSize = new Size();

            int startX = pt.X;
            int startY = pt.Y;
            int endX = sz.Width + pt.X;
            int endY = sz.Height + pt.Y;

            squareSize = new Size(sz.Width / data.gridSize, sz.Height / data.gridSize);

            //Here, we also do the string fit.
            Font seedFont = new Font(FontFamily.GenericMonospace, 50); //Start with a big font
            string letter = "M";
            Size stringSize = new Size();
            Font stringFont = resizeString(letter, squareSize, seedFont, ref graphicsObj, ref stringSize);
            Font drawFont;

            for (int rows = data.gridSize - 1; rows >= 0; rows--)
            {
                for (int cols = 0; cols < data.gridSize; cols++)
                {
                    Point drawPt = new Point(startX + squareSize.Width * rows, startY + squareSize.Height * cols);
                    rect = new Rectangle(drawPt, squareSize);
                    if (data.printGrid == true)
                    {
                        graphicsObj.DrawRectangle(myPen, rect);
                    }

                    Point letterPt = new Point(drawPt.X, drawPt.Y + (squareSize.Height - stringSize.Height) / 2);  //Center the letter in the gridbox
                    letter = data.puzzle.grid[rows, cols].ToString().ToLower();
                    if (letter == " ")
                    {
                        letter = lettersByFrequency[rand.Next() % lettersByFrequency.Length].ToString();
                        drawFont = new Font(stringFont, FontStyle.Regular);
                    }
                    else if (showSolution == true)
                    {
                        drawFont = new Font(stringFont, FontStyle.Bold);
                    }
                    else
                    {
                        drawFont = new Font(stringFont, FontStyle.Regular);
                    }

                    //stringFont.Style = FontStyle.Bold;

                    graphicsObj.DrawString(letter, drawFont, blackBrush, letterPt);
                }
            }
        }

    }

    public class puzzleDataFile
    {
        public List<string> words = new List<string>();
        public string titleText = "Word Search";
        public string titleTextFont = "Verdana";
        public string AllowedDirections = "15";
        public string filePath = "";
        public int titleFontSize = 24;
        public int titleTextBuffer = 10; //Buffer size in px
        public int gridSize = 15;
        public int cardsPerPage = 1;
        public int numCardsToPrint = 1;
        public bool printGrid = true;
        public bool printSolution = true;
        public bool printWordList = true;
        public bool showSolution = true;
        public bool printTitle = false;


        public int bool2int(bool value) {
            if (value == true) {
                return(1);
            }
            return(0);
        }

        public bool string2bool(string str) {
            int value = -1;
            
            try {
            value = Int32.Parse(str);
            }
            catch {
                value = 1;
            }

            if (value <= 0) {
                return (false);
            }
            return(true);
        }

        public puzzleDataFile(string filePath)
        {
            this.filePath = filePath;
        }

        public puzzleDataFile(List<string> words, bool printTitle, string titleText, string titleTextFont, int titleFontSize, int titleTextBuffer, int gridSize, int cardsPerPage, int numCardsToPrint, bool printGrid, bool printSolution, bool printWordList, bool showSolution, string AllowedDirections, string filePath)
        {


            if (words != null)
            {
                this.words = words;
            }
   
    
                this.printTitle = printTitle;
            
            if (titleText != null)
            {
                this.titleText = titleText;
            }
            if (titleTextFont != null)
            {
                this.titleTextFont = titleTextFont;
            }
   
                this.titleFontSize = titleFontSize;
            
                this.titleTextBuffer = titleTextBuffer;
            
                this.gridSize = gridSize;
            
                this.cardsPerPage = cardsPerPage;
          
                this.numCardsToPrint = numCardsToPrint;
          
                this.printGrid = printGrid;
          
                this.printSolution = printSolution;
           
                this.printWordList = printWordList;
           
                this.showSolution = showSolution;
            
            if (AllowedDirections != null)
            {
                this.AllowedDirections = AllowedDirections;
            }
            //if (filePath != null)
            //{
                this.filePath = filePath;
            //}



        }
    }

       public class WordSearchFileFuncs
        {

            List<string> fileList;

            public WordSearchFileFuncs()
            {
                fileList = new List<string>();

            }

            //public puzzleDataFile openFile(string filePath)
            //{

            //    BingoWordFile file = new BingoWordFile(filePath);
            //    int printTitle = 0;
            //    int printFreeSpace = 0;

            //    Cursor.Current = Cursors.WaitCursor;

            //    try
            //    {
            //        using (DbConnection configdb = new SQLiteConnection("Data Source=" + file.filePath))
            //        {
            //            using (DbCommand cmd = configdb.CreateCommand())
            //            {

            //                configdb.Open();

            //                cmd.CommandText = "SELECT * FROM 'info'";
            //                try
            //                {
            //                    using (DbDataReader reader = cmd.ExecuteReader())
            //                    {
            //                        while (reader.Read())
            //                        {
            //                            try
            //                            {
            //                                file.cardTitleText = reader["cardtitletext"].ToString();
            //                            }
            //                            catch
            //                            {
            //                                file.cardTitleText = "";
            //                            }
            //                            try
            //                            {
            //                                file.cardFreeSpaceText = reader["cardfreespacetext"].ToString();
            //                            }
            //                            catch
            //                            {
            //                                file.cardFreeSpaceText = "";
            //                            }
            //                            try
            //                            {
            //                                file.cardRowSize = int.Parse(reader["cardrowsize"].ToString());
            //                            }
            //                            catch
            //                            {
            //                                file.cardRowSize = 5;
            //                            }
            //                            try
            //                            {
            //                                file.cardColSize = int.Parse(reader["cardcolsize"].ToString());
            //                            }
            //                            catch
            //                            {
            //                                file.cardColSize = 5;
            //                            }
            //                            try
            //                            {

            //                                file.numCardsToPrint = int.Parse(reader["numcardstoprint"].ToString());
            //                            }
            //                            catch
            //                            {
            //                                file.numCardsToPrint = 1;
            //                            }
            //                            try
            //                            {
            //                                file.numCardsPerPage = int.Parse(reader["numcardsperpage"].ToString());
            //                            }
            //                            catch
            //                            {
            //                                file.numCardsPerPage = 1;
            //                            }
            //                            try
            //                            {
            //                                printTitle = int.Parse(reader["printTitle"].ToString());
            //                            }
            //                            catch
            //                            {
            //                                printTitle = 0;
            //                            }

            //                            if (printTitle >= 1)
            //                            {
            //                                file.printTitle = true;
            //                            }
            //                            else
            //                            {
            //                                file.printTitle = false;
            //                            }

            //                            try
            //                            {
            //                                printFreeSpace = int.Parse(reader["printFreeSpace"].ToString());
            //                            }
            //                            catch
            //                            {
            //                                printFreeSpace = 0;
            //                            }

            //                            if (printFreeSpace >= 1)
            //                            {
            //                                file.printFreeSpace = true;
            //                            }
            //                            else
            //                            {
            //                                file.printFreeSpace = false;
            //                            }
            //                        }
            //                    }
            //                }
            //                catch
            //                {
            //                }


            //                cmd.CommandText = "SELECT * FROM 'wordlist'";
            //                try
            //                {
            //                    using (DbDataReader reader = cmd.ExecuteReader())
            //                    {
            //                        while (reader.Read())
            //                        {
            //                            try
            //                            {
            //                                file.wordList.Add(reader["word"].ToString());
            //                            }
            //                            catch
            //                            {
            //                            }
            //                        }
            //                    }
            //                }
            //                catch
            //                {
            //                }


            //                configdb.Close();
            //            }



            //        }
            //    }
            //    catch
            //    {

            //    }

            //    finally
            //    {
            //        Cursor.Current = Cursors.Default;


            //    }
            //    return (file);
            //}

            public puzzleDataFile readFile(string filePath)
            {
                puzzleDataFile file = new puzzleDataFile(filePath);
                file.filePath = filePath;

                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    using (DbConnection configdb = new SQLiteConnection("Data Source=" + file.filePath))
                    {
                        using (DbCommand cmd = configdb.CreateCommand())
                        {
                            configdb.Open();

                            cmd.CommandText = "SELECT * FROM 'wordsearchinfo'";

                            try
                            {
                                using (DbDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        try
                                        {
                                            file.titleText = reader["titletext"].ToString();
                                        }
                                        catch
                                        {
                                            file.titleText = "Word Search";
                                        }
                                        try
                                        {
                                            file.titleTextFont = reader["titletextfont"].ToString();
                                        }
                                        catch
                                        {
                                            file.titleTextFont = "Verdana";
                                        }
                                        try
                                        {
                                            file.AllowedDirections = reader["alloweddirections"].ToString();
                                        }
                                        catch
                                        {
                                            file.AllowedDirections = "15";
                                        }
                                        try
                                        {

                                            int titleFontSize = Int32.Parse(reader["titlefontsize"].ToString()); //One extra step to keep the exception from corrupting the value of titlefontsize.
                                            file.titleFontSize = titleFontSize;

                                        }
                                        catch
                                        {
                                            file.titleFontSize = 24;
                                        }
                                        try
                                        {
                                            int gridSize = Int32.Parse(reader["gridsize"].ToString());
                                            file.gridSize = gridSize;
                                        }
                                        catch
                                        {
                                            file.gridSize = 15;
                                        }
                                        try
                                        {
                                            int titleTextBuffer = Int32.Parse(reader["titletextbuffer"].ToString());
                                            file.titleTextBuffer = titleTextBuffer;
                                        }
                                        catch
                                        {
                                            file.titleTextBuffer = 10;
                                        }
                                        try
                                        {
                                            int cardsPerPage = Int32.Parse(reader["cardsperpage"].ToString());
                                            file.cardsPerPage = cardsPerPage;
                                        }
                                        catch
                                        {
                                            file.cardsPerPage = 1;
                                        }
                                        try
                                        {
                                            int numCardsToPrint = Int32.Parse(reader["numcardstoprint"].ToString());
                                            file.numCardsToPrint = numCardsToPrint;
                                        }
                                        catch
                                        {
                                            file.numCardsToPrint = 1;
                                        }
                                        try
                                        {
                                            file.printGrid = file.string2bool(reader["printgrid"].ToString());
                                        }
                                        catch
                                        {
                                            file.printGrid = true;
                                        }
                                        try
                                        {
                                            file.printSolution = file.string2bool(reader["printsolution"].ToString());
                                        }
                                        catch
                                        {
                                            file.printSolution = true;
                                        }
                                        try
                                        {
                                            file.printWordList = file.string2bool(reader["printwordlist"].ToString());
                                        }
                                        catch
                                        {
                                            file.printWordList = true;
                                        }
                                        try
                                        {
                                            file.showSolution = file.string2bool(reader["showsolution"].ToString());
                                        }
                                        catch
                                        {
                                            file.showSolution = true;
                                        }
                                        try
                                        {
                                            file.printTitle = file.string2bool(reader["printtitle"].ToString());
                                        }
                                        catch
                                        {
                                            file.printTitle = false;
                                        }

                                        // printsolution TEXT, printwordlist TEXT, showsolution TEXT, printtitle TEXT)";

                                    }

                                }

                            }
                            catch
                            {


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
                                            file.words.Add(reader["word"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                    }

                                }

                            }

                            catch
                            {
                                //Unable to read word list
                            }
                        }

                    }
                }
                catch
                {
                    //Unable to open file
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }

                return (file);
            }
            public bool writeFile(puzzleDataFile file)
            {

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
                                cmd.CommandText = "DROP TABLE wordsearchinfo";
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
                                // public List<string> words = new List<string>();

                                cmd.CommandText = "CREATE TABLE wordsearchinfo (titletext TEXT, titletextfont TEXT, alloweddirections TEXT, titlefontsize TEXT, titletextbuffer TEXT, gridsize TEXT, cardsperpage TEXT, numcardstoprint TEXT, printgrid TEXT, printsolution TEXT, printwordlist TEXT, showsolution TEXT, printtitle TEXT)";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = "INSERT into wordsearchinfo VALUES('" + file.titleText + "','" + file.titleTextFont + "','" + file.AllowedDirections + "','" + file.titleFontSize.ToString() + "','" + file.titleTextBuffer.ToString() + "','" + file.gridSize.ToString() + "','" + file.cardsPerPage.ToString() + "','" + file.numCardsToPrint.ToString() + "','" + file.bool2int(file.printGrid).ToString() + "','" + file.bool2int(file.printSolution).ToString() + "','" + file.bool2int(file.printWordList).ToString() + "','" + file.bool2int(file.showSolution).ToString() + "','" + file.bool2int(file.printTitle).ToString() + "')";
                                cmd.ExecuteNonQuery();
                            }
                            catch
                            {
                            }

                            try
                            {
                                cmd.CommandText = "CREATE TABLE wordlist (word TEXT)";
                                cmd.ExecuteNonQuery();

                                foreach (string item in file.words)
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
    
}
