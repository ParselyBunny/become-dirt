-> Intro


=== Intro
Our family used to do magic.
Years before I was born, our family knew hundreds of spells and used them a dozen times each day. It was easier for them than sweeping dirt from the kitchen floor. Now we only have three spells left.
My grandmother knows them all - She learned them when she was young and practiced every day to keep them clear in her mind. She told me, before I was old enough to understand, that it was her responsibility to make sure we didn't lose the last of our magic.
Normally my mother would be the one to teach us, but she can't do magic at all. She never could. I heard that when I was born, my grandmother was overjoyed and nearly cracked a smile as she held me. 
She could tell I had the talent for magic, but even with all the lessons she gave me I could only ever use the most useless of our family's spells. Become Dirt - the spell that makes you worthless.
My younger brother is better at it than me - Magic, that is. He learned our family's strongest spell without any trouble. 
Become Mechanical, the spell my grandmother used to work beyond her own limits and raise a daughter on her own without ever breaking or slowing down. He's a really smart kid, and he's a lot more responsible than I ever was. 
Recently, though, he's been afraid of something. I don't know what he's worried about, but he always seems anxious and uneasy these days. 
My grandmother wants to make sure he knew all the family's magic so that he can pass it on one day, and he's been making great progress. I don't know what would make him so frightened... 
I should check on him today.
    ->CallOut

    =CallOut
        SISTER: Brother!
        His bus should have stopped by about an hour ago, so he should be here. 
        SISTER: ...Brother?"
        
        Maybe he's in the hideout. He's been going down there a lot more lately. 
        I should check our room first, at least.
        -> GrandmotherConvoA
    
    

    =GrandmotherConvoA
        GRANDMOTHER: You. You're home late.
        SISTER: O-oh, yeah. I had to stay after for a make-up test.
        GRANDMOTHER: ...
        SISTER: Has Brother made it home yet?
        GRANDMOTHER: He returned on time and should be studying now. Had you studied more effectively, you would have saved yourself over an hour and twenty minutes. 
        SISTER: I just got unlucky this time, the test wasn't that hard I just messed up a few formulas. I did really well this time, I think. Enough to pass, definitely.
        GRANDMOTHER: ...
        GRANDMOTHER: Time wasted, young lady... It will not come back to you. 
        SISTER: Ah, haha, yeah. Um, did you need anything? I can make some tea, if you'd like.
        GRANDMOTHER: I do not need tea. Caffeine will ruin you, especially this close to dinner. Didn’t you burn yourself on the kettle yesterday?
        #shake
        SISTER: Ow!
        GRANDMOTHER: To think that your school allows you to take an exam a second time after failure. What purpose does a test serve if failure has no consequences?
        GRANDMOTHER: I only hope that one day you realize how damaging your lack of diligence has been. Given your lack of aptitude with the family arts, you should be putting more effort into your schoolwork.
        GRANDMOTHER: You will not have the luxury of failure forever. When you become an adult, however long it may take you, failure is unacceptable. There will be no leniency. 
        GRANDMOTHER: When I was left to shepherd the family arts while raising your mother all on my own, there were never extensions or convenient make-up tests. 
        GRANDMOTHER: You will be tested daily in life. You must pass each and every time, each and every day. What would have happened if I hadn't worked hard enough to support your mother? What would have happened if I had spent my time making baubles and playing in the dirt as you do? We would have lost everything. Our home. Our lives. All knowledge of our family arts. Each of us bears this responsibility.
        GRANDMOTHER: I know you tire of hearing about this, and that is exactly why I will say it again. Do you think that politely offering to poorly make tea and trawl for sympathy from your own clumsiness will help you in this life? 
            ->GrandmotherLoop
        
            =GrandmotherLoop
            
                GRANDMOTHER: Well?
                GRANDMOTHER: Answer me. Idle silence is a mark of sloth.
                
                +Sorry...
                    GRANDMOTHER: Why is it that you only apologize when we catch you misbehaving? A girl who felt remorse would apologize on her own.
                    #shake
                    GRANDMOTHER: Apologies are important, but an apology without change is meaningless. To my eyes, you have not changed your behavior in the slightest.
                    GRANDMOTHER: Now, speak clear and plainly. 
                    SISTER: ...
                
                    ->GrandmotherLoop
                    
                *I've been getting better at making tea.
                    #shake
                    GRANDMOTHER: An excuse and a lie. 
                    SISTER: Ow! I-I'm sorry.
                    GRANDMOTHER: Changing the subject does not change the reality of your performance. 
                    GRANDMOTHER: Confront your failure directly. Do you understand why you cannot brew a satisfactory cup of tea?
                    GRANDMOTHER: ...Answer.
                    SISTER: I... probably steep it too long, or use too much sugar.
                    GRANDMOTHER: And this is why you do not improve. You pour boiling water over mass produced bags of dust swept from the dregs of a factory floor. Every cup you make will be disgusting regardless of how precisely you time your preparations.
                    GRANDMOTHER: Proper tea requires proper ingredients. Do you have fresh leaves? Clean and balanced water? Clear honey? You may as well steep cardboard without that.
                    SISTER: Those are the only teabags we have though...
                    #shake
                    GRANDMOTHER: This is where you fail. Do you see? You try to perfect swill rather than going out to find quality ingredients. Your failure on this recent exam is the same. 
                    GRANDMOTHER: Do you see?
                    
                    ->GrandmotherLoop
                *I should go study more, you're right...
                    GRANDMOTHER: Correct. Now tell me: How will you study?
                    GRANDMOTHER: Your previous study habits have failed. Repeating your  deficient methods will lead to the same deficient result.
                        ->GrandmaStudyQ
                        
                    =GrandmaStudyQ
                        *I don't know.
                            GRANDMOTHER: And how do you plan to learn? 
                            GRANDMOTHER: Do you reflect on your teacher's words? Do you listen to my advice? Have you asked your peers? Do you have a tutor? If you don't have an answer, then seek one.
                            GRANDMOTHER: Your apathy is fatal, young lady. It will kill your mind and lead you to sloven habits. 
                            SISTER: I'm sorry.
                            #shake
                            SISTER: Ow!
                            GRANDMOTHER: Apologies without action are meaningless. I've told you as much before, haven't I?
                        ->GrandmotherLoop
                        *I'll go over my homework again...?
                            GRANDMOTHER: Homework that you turned in late? That you didn't complete? 
                            ## Time a gasp or wince here, preparing for a pinch that doesn't come
                            GRANDMOTHER: ...
                            GRANDMOTHER: Please do not think that I lecture you out of scorn. 
                            GRANDMOTHER: Time wasted will not come back to you. If I thought you a waste of my time, I would not offer you so much of it. Do you understand?
                            SISTER: Y-yes. Of course, I know you only do it because you care and want me to do my best.
                            GRANDMOTHER: No. Not your best. I want you to do exceptionally. Your best may not be enough, but you can do more than your best. You can push yourself further. 
                            GRANDMOTHER: Now, answer me again. How will you study differently this time?
                            ->GrandmaStudyQ
                        *Could you help me with it?
                            GRANDMOTHER: ...
                            GRANDMOTHER: No. 
                            ->END
                        * ->
                
                        ##Become Dirt
                          ##  ->BECOMINGDIRT
                            
                            ##=BECOMINGDIRT
                              ##  NOTIFICATION: Use the BECOME DIRT spell to escape difficult conversations, become unremarkable, or otherwise Survive terrifying situations. 
                            ##    FLAVORTEXT: Pride, Dignity, Shame, and Defiance: Dirt has no need of these. Dirt exists beneath us, always, humble and replete with filth and vermin unfit to entertain the Sun. Despite this, dirt will remain even when all else is lost. One day, the dirt will be all that remains of us all. 
                
                            ##SISTER: Haha, you’re right. I can’t even boil water without burning myself. Thank you for looking out for me. I’d probably be dead if you weren’t stopping me from doing stupid things like that... thank you.
                            ##GRANDMOTHER:...
                            ##GRANDMOTHER: Time wasted will not come back. You have homework to do now, do you not?
                            ##SISTER: Yes, you're right. Thank you. I need to put in more effort.
                            ##GRANDMOTHER: ...
                
    
    
        -I don’t know what my grandma is thinking. I don’t think I’ve ever known, even when she told me. 
        I don’t think it’s hard to tell, I’m just not good at understanding other people sometimes. That’s why, even when she’s mad at me and I know it’s not my fault, I don’t really have a reason to argue. 
        Even if it’s not my fault, I probably deserve the blame anyway.     
            ->END
    
        
    =ExplorationA
    
        My younger brother and I share a room at the end of the hall. 
        There's not a lot of space for either of us, but we spend about as much time in our hideout as we do here so it's never been a problem.
        SISTER: Brother?
        He's not here. It looks like he was doing his schoolwork up until a moment ago, though.
            ->END
        
    =ExplorationA2
        Oh, he got a 97. He is smart, after all. 
        He studies every night, too... I try to do that, but it's hard for me to focus on anything when I see that many letters on a page at the same time. 
        I mostly try to study to make sure he doesn't worry about me, but most of the time all I can do is look at the paper and trace lines through the blank spaces with my eyes. 
        There's a report here... it must be the one he's working on for school this week. It looks like the topic is "My Future Job." He was asking me about the future just the other day too...
    
    ->RecollectionA
    
    
        =RecollectionA
    
        BROTHER: SISTER. You're back early.
        SISTER: Yep! Hey, there were some extra quarters on the ground under the vending machine at school so I got you a twix.
        BROTHER: ! A whole twix!
        SISTER: Yeah, haha.
        BROTHER: Here.
        SISTER: Huh? No, I got it for you. You don't have to give me half or anything, I'm not hungry right now anyway.
        BROTHER: Are you lying?
        SISTER: Yeah, about not being hungry. But I'm telling the truth about getting the whole thing for you so just take it, okay?
        BROTHER: ...Thanks. You're weird.
        SISTER: Ah, haha... Yeah, probably.
        BROTHER: Hey. 
        SISTER: Hm?
        BROTHER: What do you put down when teachers ask you about your future career?
        SISTER: I...
        The truth is, I don't put any effort into things like that. Sometimes I write something really generic like, I'd like to be a receptionist at a dentist's office. 
        I'd like to be an office worker at one of the banks downtown. I don't really want either of those things but I don't have any other ideas either, and those answers always satisfy the teachers so it works out for the best that way.
        SISTER: I usually write something practical. 
        SISTER: It's the future so it'll probably change a lot, and it's not like we really know what jobs will hire us or how long we'll be able to stay. 
        BROTHER: My teacher told me that we should write our report about what we think our future job will be, and then look up what people with that job do. 
        BROTHER: It can't be a job anyone in our family has either, since we already did a family interview paper six weeks ago.
        BROTHER: Mom's got two right now and I don't think either of them are things she wrote down when she did her 3rd grade assignments.
        SISTER: Maybe she did. You never know.
        BROTHER: You know she didn't.
        SISTER: It's ok if you change your mind when you get older, that happens a lot. When I was  your age I said I wanted to be an acrobat in the circus and a firefighter, but I'm pretty useless at things like that so... I'm not really sure now.
        BROTHER: You're not useless. You can make things out of clay.
        SISTER: Ah, yeah. I can do that, at least.
        Making weird animals out of dirt from the crawl space probably won't make much impact on society or pay my bills, though.
        SISTER: Anyway don't think too much about it. Just write down the first thing you think you want to do, right? It's ok if it changes.
        BROTHER: I... don't want it to change.
        SISTER: Hm? What'd you say?
        BROTHER: Hey. What should I put down if I just want to learn all of grandma's spells?
        SISTER: What? 
        BROTHER: I need to learn all of them, so that's what I'll put down. Is 'Family Business' okay?
        SISTER: You don't have to. If you don't really want to, you don't have to learn all the family arts. I learned one spell already, right? So I can definitely learn more.
        BROTHER: I’m good at it though. Grandma said I’m good at it, and if I do this then they won’t yell at you as much.
    
        He kept staring down at his half-written report the whole time we talked. His clothes and the page were covered in eraser shavings.
        
        I should check on him.
        ->END
        
    =FearA
        SISTER: Was that-
        ## FearA - Door disappearance 
        NOTIFICATION: When confronted with overwhelming horror, you can use the BECOME DIRT spell to fall beneath the notice of all monsters, menaces, and members of your family. Take care when using this spell over loose floorboards or open grates. 
    
        ## BECOME DIRT falling through the floorboards effect here
        
        SISTER: *coughing*
        SISTER: Ow... Why does falling through the floor always hurt my stomach like that. 
        SISTER: ...
        
        The air ducts are all moved around. I don't think I can get to the hideout like this.
        
        SISTER: Brother? Brother!
        
        Did he block the way on purpose? He can't lift things this heavy but - oh, if he used grandma's spell he could. Why would he do that, though?
        
        ## After a brief exploration here, eyes appear in the dark
        
        SISTER: Brother? Hey, are you over there?
        BROTHER?: ...
        SISTER: Um. I had some ideas for some stuff we could add to the hideout today. Do you have the flashlight down here?
        BROTHER?: ...
        SISTER: Ah, that's ok. I can go get it if you don't. Did you have lessons again today?
        BROTHER?: ...
        
        ## The eyes fade and a sound erupts, giving the clear impression of a massive, clearly inhuman creature moving through the crawlspace.
        
        ...
        He and I are the only two people who ever come down here. Not even raccoons or squirrels go down into the crawl space. 
        That had to be him.
        And then, upstairs...
        
        ->END
    =CrawlSpaceA


---That monster was one he told me about, from a nightmare of his.
---I need to get back upstairs.

->END


=== GateOne

    =Realization
    ## Return to the house proper, via the hole in the laundry room.
        Our Family only has three spells left, and only one of them is worth using. 
        Become Dirt, the oldest spell, makes you into something completely useless and common and pathetic. It's the only spell I ever learned, maybe because I'm already useless even without magic.
        Become Mechanical is my grandma's specialty and it's probably the only reason our family still exists. 
        It's an incredible spell that turns your body into a machine and makes it possible to do almost anything, no matter how much it hurts or how tired you are or how much your brain is screaming for you to stop. 
        Grandma told us about how her parents and grandparents used this magic to work perfectly and past the point when their bodies would have normally given out, all so that they could keep moving up in their careers and ensure the family's prosperity. 
        Everything fell apart when it turned out that my mom couldn't use any magic at all. She works really hard, maybe harder than our ancestors did, 
        but she can't keep a smile up all the time and she has to call off work sometimes because of her back and knees, or when one of us gets sick.
        Maybe if I was old enough to work, and if I could use Become Mechanical, things would be better for us... though I don't know if mom would like me any better in that case.
        The last spell our family keeps is forbidden. Become Dirt and Become Mechanical are temporary spells that you can use while you need them and stop when you're done. Become Fear isn't like that. 
        Become Fear is a spell you use as an absolute last resort, a spell that will keep you from ever feeling afraid by turning you into every horrible and terrifying thing you've ever known. 
        Nothing can frighten you if you're the scariest thing around, after all. My grandma tried to teach me about it, once, but since I don't have any talent for magic she never told me how to actually cast it. 
        It's a spell that requires you to discard everything that makes you a person, and it's a spell you can't break or end on your own. 
        
        I think... my brother used Become Fear. 
        I need to find a way down into our hideout, in the far corner of the crawl space.
        
        ->END

=== Explanatory
    =FrontDoor1
        I locked this right?
        ...
        Yeah. 
        Mom will be home soon and she gets worried whenever she finds the door unlocked.
        ->END
    =FrontDoor2
        Yeah, definitely locked. 
        Definitely.
        ->END
    =SideDoor
        There's a wasp trapped between the side door and its screen door.
        Sorry, I'll go around the house and let you out later, if I can.
        ->END
    =MomDoorLocked
        Mom keeps her door locked. It's not that she hates the idea of us going into her room, but she just doesn't feel safe unless everything stays locked all the time. 
        ->END
    =CrawlSpaceHatch
        ->END
=== Explorations

    =BathroomExplore
        *Mirror
            I hate the way sink scum dries on the mirror. Every time you look at yourself, you're surrounded by little bits of toothpaste, water mixed with soap from washing our hands and faces, and a few smudges I don't want to really think about. We clean it, of course, but a lot of these stains won't come off anymore.
            ->END
        *Sink
            We just unclogged it last week so it finally drains alright. 
            ->END
        *Toilet
            The fluffy cover on the toilet lid always stares back at me before I lift it. 
            ->END
        
        
    =SiblingRoomExplore
        *BunkBed
            The bunk bed where my brother and I sleep. The bottom bunk is his, since I kept banging my head on the top bunk when I used to sleep down there. 
            He asked me to switch one day, saying he was scared of heights and wanted to be closer to the ground. I'm pretty sure he was just being considerate.
            ->END
        *SisterBooks
            A faded copy of Northanger Abbey rests under a pile of overstretched hair ties and flavored chapstick. 
            ->END
        *dresser
            When I was seven I ruined my dresser with glitter stickers, so now the handles are covered in sticky dust and gunk. 
            I thought I learned a really valuable lesson the day Mom yelled at me and made me scrape the stickers off one by one, but yesterday I scratched the varnish trying to open the top drawer. 
            ->END
        *SiblingDesk
            Two of grandma's old magic books are laid out on top of Brother's homework.
            None of us can use the spells in most of her old books, but she makes him study all of them anyway. 
            ->END
    =HallExplore
        *MomDoor
            #This should only become active after Mother arrives home and while she's in the room
            I can hear Mom watching The Young & The Restless through the door. Cricket died again, I think.
        ->END
    =LivingRoomExplore
        *Fireplace
            I don't think we've ever used this. Every few months Mom says she needs to get it cleaned, but we've never been able to afford it.
            ->END
        *DiningTable
            **Brother's Setting
                My brother's setting at the table. I don't remember when we both started sitting side by side all the way on this end. It's just how we've always done things.
                ->END
            **Brother's Setting 2
                There are old crayon marks on the edge of the table here. When he was younger, Brother used to color the edges of all his assignments because he liked it when paper had borders. 
                ->END
            **My Setting
                My place at the table. It's quiet in the corner.
                ->END
            **My Setting 2
                We don't eat meals as a family very often anymore. 
                ->END
            **Mom's Setting
                Mom's seat at the table. She's got a few mugs of coffee around the house.
                ->END
            **Mom's Setting 2
                I'm never sure if I should clean out her old mugs or not. Last time she got mad at me for dumping her coffee, but last week she told me I shouldn't just leave old mugs lying around if I see them when I do dishes. 
                ->END
            **Grandma's Setting
                Our Grandma's seat at the table. She uses it like a desk when she teaches my little brother magic. His practice pages are scattered around the floor in this corner.
                ->END
        *Bookcase
            **Top Shelf
                The top shelf is full of reference books that Mom got at a yard sale. A lot of the encyclopedia sets are missing volumes, but I did use a couple of these for school once.
                ->END
            **Middle Shelves
                Most of the bookcase is full of used paperbacks and discards from the library. Mom says she reads these all the time, but they never leave the bookcase.
                ->END
            **Bottom Shelf
                Cookbooks and a couple of gardening books fill the bottom shelf, like Microwave Chef and Southern Homes & Gardens. 
                ->END
        *Sofa
            The sofa is well worn. Not by us - we almost never use them anymore. Someone else wore the springs down and ripped the cushion. 
            ->END
        *Sofa2
            Creaky and comfy.
            ->END
        *Armchair
            Mom's Armchair. She sits here and drinks her coffee after dinner almost every night.
            ->END
        *LivingRug
            Sometimes, when I'm tired, I'll come in here and stare at this rug to space out. The pattern looks like it starts moving after a while, like watching a popcorn ceiling through fan blades.
            ->END
    =LaundryExplore
        *WashDryer
            Our dryer, and our wet-er. 
            ->END
        *LintBucket
            Mom's lint bucket. She uses this for her plushies. 
            ->END
    =KitchenExplore
            ->END
    =PantryExplore
        *PastaShelf
            Pasta is nice, when it’s just pasta. Last week I made a bowl of macaroni and I finished half of it before I realized there were moth worms dangling out of the elbow noodles. They were boiled long enough to be safe though, I think, and it’s bad to waste food. 
            ->END
        *CanShelf
            Canned pears, carrots, corn, peas, green beans, kidney beans, navy beans, black beans, refried beans, and beets.
            Mom gets as many of these as she can on sale, since she can't go to the grocery store often.
            ->END
    =CrawlSpaceExplore
        *VentilationDuct
            These ducts hum and rattle when the A/C or heater turns on.
            Brother and I used to lay rocks on them to make noises whenever the A/C started up, but Grandma noticed right away. 
            ->END
