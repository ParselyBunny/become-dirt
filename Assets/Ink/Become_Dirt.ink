-> Intro

#Change flow of game through GO TO CRAWLSPACE, SEARCH AROUND, BROTHER CONVO, longer time for uncertainty around Brother condition, dirt in crawlspace is simply Moving Around Like That hahaha nORMAL. Direction to go back to the crawlspace, search around, find that you can’t get to the hideout, and try to get up and around the house. 

=== Intro
Our family used to do magic.
Years before I was born, our family knew hundreds of spells and used them a dozen times each day. It was easier for them than sweeping dirt from the kitchen floor. Now we only have three spells left.
My grandmother knows them all - She learned them when she was young and practiced every day to keep them clear in her mind. She told me, before I was old enough to understand, that it was her responsibility to make sure we didn’t lose the last of our magic.
Normally my mother would be the one to teach us, but she can’t do magic at all. She never could. I heard that when I was born, my grandmother was overjoyed and nearly cracked a smile as she held me. 
She could tell I had the talent for magic, but even with all the lessons she gave me I could only ever use the most useless of our family’s spells. Become Dirt - the spell that makes you worthless.
My younger brother is better at it than me - Magic, that is. He learned our family’s strongest spell without any trouble. 
Become Mechanical, the spell my grandmother used to work beyond her own limits and raise a daughter on her own without ever breaking or slowing down. He’s a really smart kid, and he’s a lot more responsible than I ever was. 
Recently, though, he’s been afraid of something. I don’t know what he’s worried about, but he always seems anxious and uneasy these days. 
My grandmother wants to make sure he knew all the family’s magic so that he can pass it on one day, and he’s been making great progress. I don’t know what would make him so frightened... 
I should check on him today.
// -> END
-> GrandmotherConvoA

    =CallOut
        SISTER: Brother!
        His bus should have stopped by about an hour ago, so he should be here. 
        SISTER: ...Brother?"
        
        Maybe he’s in the hideout. He’s been going down there a lot more lately. 
        I should check our room first, at least.
        -> END
    
    =GrandmotherConvoA
        GRANDMOTHER: You. You’re home late.
        SISTER: O-oh, yeah. I had to stay after for a make-up test.
        GRANDMOTHER: ...
        SISTER: Has Brother made it home yet?
        GRANDMOTHER: He returned on time and should be studying now. Had you studied more effectively, you would have saved yourself over an hour and twenty minutes. 
        SISTER: I just got unlucky this time, the test wasn’t that hard I just messed up a few formulas. I did really well this time, I think. Enough to pass, definitely.
        GRANDMOTHER: ...
        GRANDMOTHER: Time wasted, young lady... It will not come back to you. 
        SISTER: Ah, haha, yeah. Um, did you need anything? I can make some tea, if you’d like.
        GRANDMOTHER: I do not need tea. Caffeine will ruin you, especially this close to dinner. Didn’t you burn yourself on the kettle yesterday?
        #shake
        SISTER: Ow!
        GRANDMOTHER: To think that your school allows you to take an exam a second time after failure. What purpose does a test serve if failure has no consequences?
        GRANDMOTHER: I only hope that one day you realize how damaging your lack of diligence has been. Given your lack of aptitude with the family arts, you should be putting more effort into your schoolwork.
        GRANDMOTHER: You will not have the luxury of failure forever. When you become an adult, however long it may take you, failure is unacceptable. There will be no leniency. 
        GRANDMOTHER: When I was left to shepherd the family arts while raising your mother all on my own, there were never extensions or convenient make-up tests. 
        GRANDMOTHER: You will be tested daily in life. You must pass each and every time, each and every day. What would have happened if I hadn’t worked hard enough to support your mother? What would have happened if I had spent my time making baubles and playing in the dirt as you do? We would have lost everything. Our home. Our lives. All knowledge of our family arts. Each of us bears this responsibility.
        GRANDMOTHER: I know you tire of hearing about this, and that is exactly why I will say it again. Do you think that politely offering to poorly make tea and trawl for sympathy from your own clumsiness will help you in this life? 
        ->GrandmotherLoop
        
    =GrandmotherLoop
        GRANDMOTHER: Well?
        GRANDMOTHER: Answer me. Idle silence is a mark of sloth.
    
        * Sorry...
            GRANDMOTHER: Why is it that you only apologize when we catch you misbehaving? A girl who felt remorse would apologize on her own.
            #shake
            GRANDMOTHER: Apologies are important, but an apology without change is meaningless. To my eyes, you have not changed your behavior in the slightest.
            GRANDMOTHER: Now, speak clear and plainly. 
            SISTER: ...
            ->GrandmotherLoop
    
       * I’ve been getting better at making tea.
            #shake
            GRANDMOTHER: An excuse and a lie. 
            SISTER: Ow! I-I’m sorry.
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
    
        * I should go study more, you’re right...
            GRANDMOTHER: Correct. Now tell me: How will you study?
            GRANDMOTHER: Your previous study habits have failed. Repeating your  deficient methods will lead to the same deficient result.
            ->GrandmaStudyQ
        
        *BECOMEDIRT
            ->BECOMINGDIRT
        
        - I don’t know what my grandma is thinking. I don’t think I’ve ever known, even when she told me. 
        I don’t think it’s hard to tell, I’m just not good at understanding other people sometimes. That’s why, even when she’s mad at me and I know it’s not my fault, I don’t really have a reason to argue. 
        Even if it’s not my fault, I probably deserve the blame anyway.     
        ->END
    
    =GrandmaStudyQ
        * I don’t know.
            GRANDMOTHER: And how do you plan to learn? 
            GRANDMOTHER: Do you reflect on your teacher’s words? Do you listen to my advice? Have you asked your peers? Do you have a tutor? If you don’t have an answer, then seek one.
            GRANDMOTHER: Your apathy is fatal, young lady. It will kill your mind and lead you to sloven habits. 
            SISTER: I’m sorry.
            #shake
            SISTER: Ow!
            GRANDMOTHER: Apologies without action are meaningless. I’ve told you as much before, haven’t I?
            ->GrandmotherLoop
        * I’ll go over my homework again...?
            GRANDMOTHER: Homework that you turned in late? That you didn’t complete? 
            // Time a gasp or wince here, preparing for a pinch that doesn’t come
            GRANDMOTHER: ...
            GRANDMOTHER: Please do not think that I lecture you out of scorn. 
            GRANDMOTHER: Time wasted will not come back to you. If I thought you a waste of my time, I would not offer you so much of it. Do you understand?
            SISTER: Y-yes. Of course, I know you only do it because you care and want me to do my best.
            GRANDMOTHER: No. Not your best. I want you to do exceptionally. Your best may not be enough, but you can do more than your best. You can push yourself further. 
            GRANDMOTHER: Now, answer me again. How will you study differently this time?
            ->GrandmaStudyQ
        * Could you help me with it?
            GRANDMOTHER: ...
            GRANDMOTHER: No. 
            GRANDMOTHER: Now, answer me again. How will you study differently this time?
            ->GrandmaStudyQ
                
    = BECOMINGDIRT
        # NOTIFICATION: "Use the BECOME DIRT spell to escape difficult conversations, become unremarkable, or otherwise Survive terrifying situations." 
        # FLAVORTEXT: "Pride, Dignity, Shame, and Defiance: Dirt has no need of these. Dirt exists beneath us, always, humble and replete with filth and vermin unfit to entertain the Sun. Despite this, dirt will remain even when all else is lost. One day, the dirt will be all that remains of us all."
    
        SISTER: Haha, you’re right. I can’t even boil water without burning myself. Thank you for looking out for me. I’d probably be dead if you weren’t stopping me from doing stupid things like that. Thank you, really.
        GRANDMOTHER:...
        GRANDMOTHER: Time wasted will not come back. You have homework to do now, do you not?
        SISTER: Yes, you’re right. The best I can do is put in more effort and hope I get a high D, but even that will be amazing for someone like me. Thank you.
        GRANDMOTHER: ... Go, then.
        -> DONE
        
    
    =BecomeDirtNotif
    NOTIFICATION: Use the BECOME DIRT spell to escape difficult conversations, crumble away from the world, become unremarkable, or otherwise Survive terrifying situations.
    FLAVORTEXT: Pride, Dignity, Shame, and Defiance: Dirt has no need of these. Dirt exists beneath us, always, humble and replete with filth and vermin unfit to entertain the Sun. Despite this, dirt will remain even when all else is lost. One day, the dirt will be all that remains of anything.
    
    I feel sick. It’s a sort of sick I can feel at the top of my stomach, like bile dripping down and leaving black splotchy stains in the center of me. 
    It happens every time I use Become Dirt, but it’s still not as bad as spending a second longer talking to my grandma.
    Really, you get used to it pretty quick.
    ->END
    
    =ExplorationA1
        My younger brother and I share a room at the end of the hall. 
        There’s not a lot of space for either of us, but we spend about as much time in our hideout as we do here so it’s never been a problem.
        SISTER: Brother?
        He’s not here. It looks like he was doing his schoolwork up until a moment ago, though.
        ->END
        
    =ExplorationA2
        Oh, he got a 97. He is smart, after all. 
        He studies every night, too... I try to do that, but it’s hard for me to focus on anything when I see that many letters on a page at the same time.
        I mostly try to study to make sure he doesn’t worry about me, but most of the time all I can do is look at the paper and trace lines through the blank spaces with my eyes. 
        There’s a report here... it must be the one he’s working on for school this week. It looks like the topic is "My Future Job." He was asking me about the future just the other day too...
        ->RecollectionA
    
    =RecollectionA
        # CUTSTART
        BROTHER: SISTER. You’re back early.
        SISTER: Yep! Hey, there were some extra quarters on the ground under the vending machine at school so I got you a twix.
        BROTHER: ! A whole twix!
        SISTER: Yeah.
        BROTHER: Here.
        SISTER: Huh? No, I got it for you. You don’t have to give me half or anything, I’m not hungry right now anyway.
        BROTHER: Are you lying?
        SISTER: Yeah, about not being hungry. But I’m telling the truth about getting the whole thing for you so just take it, okay?
        BROTHER: ...Thanks. You’re weird.
        SISTER: Definitely.
        BROTHER: Hey. 
        SISTER: Hm?
        BROTHER: What do you put down when teachers ask you about your future career?
        SISTER: I...
        
        The truth is, I don’t put any effort into things like that. Sometimes I write something really generic like, I’d like to be a receptionist at a dentist’s office. 
        I’d like to be an office worker at one of the banks downtown. I don’t really want either of those things but I don’t have any other ideas either, and those answers always satisfy the teachers so it works out for the best that way.
        
        SISTER: I usually write something practical. 
        SISTER: It’s the future so it’ll probably change a lot, and it’s not like we really know what jobs will hire us or how long we’ll be able to stay. 
        BROTHER: My teacher told me that we should write our report about what we think our future job will be, and then look up what people with that job do. 
        BROTHER: It can’t be a job anyone in our family has either, since we already did a family interview paper six weeks ago.
        BROTHER: Mom’s got two right now and I don’t think either of them are things she wrote down when she did her 3rd grade assignments.
        SISTER: Maybe she did. You never know.
        BROTHER: You know she didn’t.
        SISTER: It’s ok if you change your mind when you get older, that happens a lot. When I was  your age I said I wanted to be an acrobat in the circus and a firefighter, but I’m pretty useless at things like that so... I’m not really sure now.
        BROTHER: You’re not useless. You can make things out of clay.
        SISTER: Ah, yeah. I can do that, at least.
        Making weird animals out of dirt from the crawl space probably won’t make much impact on society or pay my bills, though.
        SISTER: Anyway don’t think too much about it. Just write down the first thing you think you want to do, right? It’s ok if it changes.
        BROTHER: I... don’t want it to change.
        SISTER: Hm? What’d you say?
        BROTHER: Hey. What should I put down if I just want to learn all of grandma’s spells?
        SISTER: What? 
        BROTHER: I need to learn all of them, so that’s what I’ll put down. Is ’Family Business’ okay?
        SISTER: You don’t have to. If you don’t really want to, you don’t have to learn all the family arts. I learned one spell already, right? So I can definitely learn more.
        BROTHER: I’m good at it though. Grandma said I’m good at it, and if I do this then they won’t yell at you as much.
    
        He kept staring down at his half-written report the whole time we talked. His clothes and the page were covered in eraser shavings.
        
        I need to check on him.
        Even though I can’t really do anything that would help...
        # CUTEND
        ->END
        
    //=FearA
      //  SISTER: Was that-
        // FearA - Door disappearance 
        //NOTIFICATION: When confronted with overwhelming horror, you can use the BECOME DIRT spell to fall beneath the notice of all monsters, menaces, and members of your family. Take care when using this spell over loose floorboards or open grates. 
        // BECOME DIRT falling through the floorboards effect here
        //->END
    =DirtAbilityTip
        NOTIFICATION: When you need to crumble away into insignificance, you can use the BECOME DIRT spell to fall beneath the notice of all monsters, menaces, and members of your family. You can use BECOME DIRT to fall into the crawlspace from the ground floor of your home.
        ->END
    
        
    =CrawlSpaceA
        SISTER: *coughing*
        SISTER: Ow... Why does falling through the floor always hurt my stomach like that. 
        SISTER: ...
        
        The air ducts are all moved around. I don’t think I can get to the hideout like this.
        
        SISTER: Brother? Brother!
        
        Did he block the way on purpose? He can’t lift things this heavy but - oh, if he used grandma’s spell he could. Why would he do that, though?
        
    // After a brief exploration here, eyes appear in the dark
        
        SISTER: Brother? Hey, are you over there?
        BROTHER?: ...
        SISTER: Um. I had some ideas for some stuff we could add to the hideout today. Do you have the flashlight down here?
        BROTHER?: ...
        SISTER: Ah, that’s ok. I can go get it if you don’t. Did you have lessons again today?
        BROTHER?: ...
        
    // The eyes fade and a sound erupts, giving the clear impression of a massive, clearly inhuman creature moving through the crawlspace.
        
        ...
        He and I are the only two people who ever come down here. Not even raccoons or squirrels go down into the crawl space. 
        That had to be him.
        And then, upstairs...
        
        That monster was one he told me about, from a nightmare of his.
        I need to get back upstairs.
        ->END


=CrawlSpaceDirt
    The dirt beneath our house moves around from time to time. I used to think there was a giant worm shifting around beneath us, but it turns out the dirt started moving around on its own when I learned how to use magic. 
    I’ve tried to get them to move around before, but they won’t listen to me and even if you try to shovel them out they’ll pile themselves back up right away.
    Of course the dirt mounds wouldn’t be a problem if the ducts weren’t in the way, but they’ve gotten moved around and twisted in weird shapes too...
    The dirt wouldn’t do that and I don’t think, my brother’s strong enough to- ah. If he used our grandmother’s spell... BECOME MECHANICAL would make anyone strong enough to tear the ductwork down from its frame.
    Why would he do that, though?
    ->END
=CrawlSpaceHomework
    This is the other page of the report he was working on. 
    ’My family is very old and pretigious and has invented many spells. My grandma is the expert on them now, and I am learning them all from her. She says that we used to have many more than 3, but now we only have 3 because of a fire and books we lost. This is sad, but I want to help so I will learn them all.
    I will enjoy this job because it will keep important spells around and they can be useful to everyone in our community. I think it is a good job because I will not be afraid knowing all the ancestors in my family are expecting a lot from me. 
    To prepare for my future job I will study every day and make sure I practice in my notebook. I will also study to get a scolarship for a college where I can study history or other languages so I can-’
    The page is harder to read after that point. It looks like he covered the whole thing with sigils he was practicing, but I can’t tell what spell they’re for.
->END

=CrawlSpaceAEnd
    I can’t lift the air ducts and these dirt mounds probably won’t move for a while. Maybe... maybe if I could fall down here from another part of the house I could just get around them altogether?
    SISTER: "Brother! Are you here?"
    #Shake
    //A sound should accompany this shake as something happens in the distance to draw player attention, maybe some dust falling from the upper floorboards? make it seem like possibly an impact on the upper floor?
    SISTER: "Hey, are you over there?"
    ...I guess not. Oh, unless he’s started a game and I didn’t realize.
    Sometimes my brother and I start games when we get back from school, but since we usually get back at different times we leave notes for each other with the rules or hints on them. I must have missed something, like usual.
    I’m not sure if this is just hide-and-seek or something else so I should look around upstairs and figure out what directions he left for me. That’s got to be it.
    Why did I even freak out about this? I’m always getting worried over nothing.
    
    ->END


===ChapterOne // Return to the house proper, via the hole in the laundry room.

=FirstCrawlspaceExit
    SISTER: I didn’t check his desk or the place at the table where he studies too closely.
    SISTER: Oh, but maybe he hid it somewhere he knew I’d look. He’s smart so he would’ve thought of that, but I probably missed it since I was so focused on looking for him. 
->END


=MomConvoA
    // After attempting to leave this area of the house [laundry/pantry/kitchen] we hear the side door close and the mother will return home.
    SISTER: Oh! W-welcome home. Your coffee’s ready, I think...
    MOTHER: I know. It’s automatic.
    SISTER: Oh, right. Um...
    MOTHER: What?
    SISTER: Nothing. Sorry.
->END
    
    =MotherConvoLoop
        MOTHER: I swear to God you spend all your time staring down at your toes and still manage to trip on every cord in the house. Learn to watch yourself! You know who’ll have to pay for it if you break another lamp or tear the TV cord out of the wall again? You wanna start an electrical fire?
        MOTHER: And the laundry’s still piled up to the brim in here - you didn’t run it like I asked, did you?
        SISTER: Sorry, I just got home.
        MOTHER: Don’t give me that. I asked you to take care of that this morning. It takes 5 seconds to pour the detergent in and press a few buttons.
        MOTHER: And now I’ve got to fix this mess... I swear to hell. 
     
        *Have you seen Brother?
            MOTHER: Don’t try and change the subject. You know full well I just got home, and he’s got a report due at the end of this week so don’t you bother him while he’s working on that. 
            MOTHER: And, dear? Try not to rip any other sockets out of the wall while you’re at it, okay?
            SISTER: I’m sorry. I-
            [SISTER trips]
            MOTHER: Watch it now! I told you to stand back, didn’t I? You don’t need to crowd in here while I fix this... I just need to grab the fool thing and get it situated right.
            ->MotherConvoLoop
        *I can fix the cord later if you want.
            MOTHER: No, I’ll fix it and you just sit still right there and watch. Once I’m done here I gotta get the stove going for dinner. I don’t have time to do the laundry so you need to start it the second I finish up here. Are you listening to me!?
            SISTER: Y-yes! Sorry...
            
            ->MotherConvoLoop
        *I’ll fix it right now, I promise!
            SISTER: I’m sorry, I’ll fix it right now! You just got home, you’re tired right? I’ll take care of it so-
            MOTHER: No you won’t. You sit right there until I get this settled. If you touch one more thing over here you’re liable to cost me a damn fortune replacing the washer. 
            
            ->MotherConvoLoop
        *Become Dirt   
            SISTER: I wasn’t paying attention, I’m sorry. I’m sorry, I need to look at where I’m going, and probably use a handrail, haha. I tripped earlier and scraped my knee on the driveway too. Sorry. I’ll start the laundry and I can do dinner too if you need!
            
            MOTHER: ...Enough.
            MOTHER: Alright. I’m gonna drink this coffee and finish emergency surgery on a tiger. By the time I get done, the laundry will be switched over and the dishwasher will be running, got it? When I check back in here I better not find a heap of wet clothes in the wash.
        
            ->END
        
        =LaundryTask
            Our Mom works really hard and fixes almost everything that breaks in the house. That’s probably why she doesn’t have a lot of patience for people who break the dishwasher every other week. I don’t do it on purpose, I promise.
            I think all the clothes are already in the machine so I just need to find the box of detergent and measure it out before I press the start button...
    
            ->END

        
        
        // Exploring around the laundry room will yield no immediate results, though you can sort of see the box of detergent having fallen back down behind the washer & dryer
        // Attempting to leave will result in the Mother calling out to you and forcing you back into the Laundry already
        
        =AttemptEscapeLaundry
        
            MOTHER: I don’t hear that washer going yet.
            SISTER: Ah, I just couldn’t find the detergent so I figured-
            MOTHER: It’s in there. Keep looking. 
            SISTER: Y-yeah.
            ->END
        
    //=BecomeVigilant
      //  I need to keep looking. Not in the normal way... I need to focus.
    
        //NOTIFICATION: Use the BECOME VIGILANT spell to notice important items around the house or to discern words within noise.
        //FLAVORTEXT: Open your eyes further. We were never meant to only see the narrow band of light before us. Movement. Breaths. The scent of a predator. The brush of wind across your neck. Sight and sense serve to bring you knowledge of the world. Know all. See all. We must be forewarned.
      //  ->END
        
    //=Vigilance
    
    //The Detergent box will be highlighted and also easily interactable whereas before its interactions were blocked. 
        //There. It probably fell from the back of the machine when the dryer was rumbling last time. 
        //Vigilance isn’t really a spell, by the way. I just got really good at noticing sounds and details because I needed to know if my mom or grandma was walking down the hall and if I should hide the clay I was working with so they didn’t get mad at me. 
        //If it was useful, that would be one thing, but I don’t think I’ve ever used it for anything but getting myself out of trouble. 
        //->END


    =ClueSearchA
        //near Grandmother Setting at table, around all the papers on the floor
        This is where my grandmother teaches my brother about magic. Most of the pages here are photocopies of the family Grimoires, since she won’t let those leave her room. It’s convenient though, since you can doodle notes all over photocopies without hurting a priceless heirloom!
        SISTER: Here, I think this is the stuff he was working on yesterday.
        //We should look at a written page that has a lot of scribbles and near the bottom the words ’I don’t want to’
        SISTER: ’I don’t want to’ what? 
        SISTER: I...
        SISTER: Maybe this isn’t a clue. What was he doing in his magic lesson yesterday? His homework was covered in scribbles like that, too.
        There’s another page here from the old Grimoire...
        GRIMOIRE: Through metaphysical configuration of concentration and spiritual essence, the will that moves the body can be applied to greater effect and additional force insuch that the very bone and sinew will all labor in accord. 
        GRIMOIRE: Flesh, as stone, exists as the matter of our Dominion and it should not dictate our action - nay, our will should dictate its motion, and its pangs and impulses consigned to their rightful place alongside other chores such as the tidying of a cupboard or the washing of a floor.
        Even now that I’m older, I don’t really understand the older family spellbooks. I think this is a page about BECOME MECHANICAL... probably. The names I use for our spells aren’t in any of the family books and my grandmother hates what I call them. 
        ’Our magic is not constrained by the artifice of Speech’ is what she says, but it’s hard for me to understand how to use them without giving them a name that makes sense. Well, I can only use one of them anyway so maybe she’s right.
    ->END
    =ClueSearchB
        //At the desk in the siblings’ room
        SISTER: Here we go, his spell practice notebook.
        SISTER: He’s never hidden clues in there before but, maybe he did this time?
        The most recent page is full of practice for the BECOME MECHANICAL sigil, and he’s drawn it about fifty times or so. They all look fine to me but he’s crossed them all out and he even tore the paper scribbling through them. I don’t understand...
        He learned the spell a month ago and he did it just fine. I think he used it in the crawlspace to rearrange the ducts even, so why would he have this much trouble with the sigil?
    ->END
    =ClueSearchC
        //Dresser near the siblings’ Bunk Bed
        SISTER: He leaves notes inside this dresser sometimes, since it’s where I keep my stash of horror books I borrow from the school library. 
        // Rustling sounds if we can get them
        SISTER: Why is it stuck?
        //Big dresser sound
        SISTER: Is that - Oh no, no it’s ruined.
        The new shirt my brother got from the thrift store last week was crammed into the back of the dresser drawer. It is - well, it was - a green t-shirt with a skateboarding dinosaur and three rocketships on it.
        Now it’s half bleached and the ink is blotted and runny. I don’t think he’s ever used bleach before so he probably didn’t realize he had to dilute it to wash out a stain. 
        I wish I could’ve cleaned it for him. I should’ve noticed earlier, since he went to school wearing it yesterday but he didn’t have it on when we were eating dinner. 
        Stupid. 
        I should’ve noticed.
    ->END
    
===ChapterTwo
=Realization
    Our Family only has three spells left, and only one of them is worth using. 
    Become Dirt, the oldest spell, makes you into something completely useless and common and pathetic. It’s the only spell I ever learned, maybe because I’m already useless even without magic.
    Become Mechanical is my grandma’s specialty and it’s probably the only reason our family still exists. 
    It’s an incredible spell that turns your body into a machine and makes it possible to do almost anything, no matter how much it hurts or how tired you are or how much your brain is screaming for you to stop. 
    Grandma told us about how her parents and grandparents used this magic to work perfectly and past the point when their bodies would have normally given out, all so that they could keep moving up in their careers and ensure the family’s prosperity. 
    Everything fell apart when it turned out that my mom couldn’t use any magic at all. She works really hard, maybe harder than our ancestors did, 
    but she can’t keep a smile up all the time and she has to call off work sometimes because of her back and knees, or when one of us gets sick.
    Maybe if I was old enough to work, and if I could use Become Mechanical, things would be better for us... though I don’t know if mom would like me any better in that case.
    The last spell our family keeps is forbidden. Become Dirt and Become Mechanical are temporary spells that you can use while you need them and stop when you’re done. Become Fear isn’t like that. 
    Become Fear is a spell you use as an absolute last resort, a spell that will keep you from ever feeling afraid by turning you into every horrible and terrifying thing you’ve ever known. 
    Nothing can frighten you if you’re the scariest thing around, after all. My grandma tried to teach me about it, once, but since I don’t have any talent for magic she never told me how to actually cast it. 
    It’s a spell that requires you to discard everything that makes you a person, and it’s a spell you can’t break or end on your own. 
    
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
        There’s a wasp trapped between the side door and its screen door.
        Sorry, I’ll go around the house and let you out later, if I can.
        ->END
    =MomDoorLocked
        Mom keeps her door locked. It’s not that she hates the idea of us going into her room, but she just doesn’t feel safe unless everything stays locked all the time. 
        ->END
    =CrawlSpaceHatch
        ->END


=== Explorations

    =Mirror
        I hate the way sink scum dries on the mirror. Every time you look at yourself, you’re surrounded by little bits of toothpaste, water mixed with soap from washing our hands and faces, and a few smudges I don’t want to really think about. We clean it, of course, but a lot of these stains won’t come off anymore.
        ->END
    =Sink
        We just unclogged it last week so it finally drains alright. 
        ->END
    =Toilet
        The fluffy cover on the toilet lid always stares back at me before I lift it. 
        ->END
    =BathTub
        My sitting place.
        ->END

    //SiblingRoomExplore
    =BunkBed
        The bunk bed where my brother and I sleep. The bottom bunk is his, since I kept banging my head on the top bunk when I used to sleep down there. 
        He asked me to switch one day, saying he was scared of heights and wanted to be closer to the ground. I’m pretty sure he was just being considerate.
        ->END
    =SisterBooks
        Ah. My Biology textbook... I need it for homework but brother left one of the magic tomes on top of it.
        ->END
    =Dresser
        When I was seven I ruined my dresser with glitter stickers, so now the handles are covered in sticky dust and gunk. 
        I thought I learned a really valuable lesson the day Mom yelled at me and made me scrape the stickers off one by one, but yesterday I scratched the varnish trying to open the top drawer. 
        ->END
    =SiblingDesk
        Two of grandma’s old magic books are laid out on top of [Brother]’s homework.
        None of us can use the spells in most of her old books, but she makes him study all of them anyway. 
        ->END
        
    =OpenTome
        Two of grandma’s old magic books are laid out on top of [Brother]’s homework.
        None of us can use the spells in most of her old books, but she makes him study all of them anyway. 
        ->END
    
    =PaperTrash
        What...is this?
        These strange icospheres on the ground, is this wax? Or some sort of soft stone used in a ritual? They seem like — oh.
        ->END
        
    =PaperTrash2
        It’s my homework from last week. It got crumbled up in the bottom of my backpack.
        ->END
    =Dragonology
        Oh, my copy of ’Dragonology’ is back here. I loved that book when I was my brother’s age, but it’s a little disheartening to think about how expensive it would be to actually see a Dragon. 
        ->END
    
    =Poster
        A poster I got from the school book fair for reading all of ’Where the Red Fern Grows’. I didn’t really like it much but the poster’s nice.
        ->END
        
    =Wardrobe
        I need to fold my clothes right. I don’t have that many pairs of jeans but they barely fit in my side because I never fold them.
        ->END
    =SiblingLaundry
        I use the laundry pile like a bean bag chair when it gets big enough, so sometimes I leave books or papers there. 
        Sometimes they get thrown in the laundry, and sometimes I have to pay a fine to the library for ruining one of their books. 
        ->END
    =ToyChest
        The large chest that holds my brother’s spare notebooks, his textbooks, my textbooks, a couple blankets for winter, and some spare candles.
        ->END

    //HallExplore
    =MomDoor
        //This should only become active after Mother arrives home and while she’s in the room
        I can hear Mom watching The Young & The Restless through the door. Cricket died again, I think.
        ->END

    //LivingRoomExplore
    =Television
        Mom watches TV here after dinner and sometimes my brother and I watch things early in the morning on weekends though we can’t make too much noise. It’s hard to hear unless we sit close and his neck starts to cramp when he has to look up for so long. 
        ->END
    =EntertainmentCenter
        I remember when we carried this home. Someone left it out by a dumpster a few years ago and Mom had me help her carry it back. It had some kind of bug living in it, so now it smells like bug spray and cologne. 
        ->END
    =Fireplace
        It’s dangerous for the fireplace to be lit when no one’s watching it. I’m watching it right now, though, so it’s safe.
        ->END

    //DiningTable
    =BrotherSetting1
        My brother’s setting at the table. I don’t remember when we both started sitting side by side all the way on this end. It’s just how we’ve always done things.
        ->END
    =BrotherSetting2
        There are old crayon marks on the edge of the table here. When he was younger, BROTHER used to color the edges of all his assignments because he liked it when paper had borders. 
        ->END
    =MySetting1
        My place at the table. It’s quiet in the corner.
        ->END
    =MySetting2
        We don’t eat meals as a family very often anymore. 
        ->END
    =MomSetting1
        Mom’s seat at the table. She’s got a few mugs of coffee around the house.
        ->END
    =MomSetting2
        I’m never sure if I should clean out her old mugs or not. Last time she got mad at me for dumping her coffee, but last week she told me I shouldn’t just leave old mugs lying around if I see them when I do dishes. 
        ->END
    =GrandmaSetting
        Our Grandma’s seat at the table. She uses it like a desk when she teaches my little brother magic. 
        ->END
    
    //Bookcase
    =TopShelf
        The top shelf is full of reference books that Mom got at a yard sale. A lot of the encyclopedia sets are missing volumes, but I did use a couple of these for school once.
        ->END
    =MiddleShelves
        Most of the bookcase is full of used paperbacks and discards from the library. Mom says she reads these all the time, but they never leave the bookcase.
        ->END
    =BottomShelf
        Cookbooks and a couple of gardening books fill the bottom shelf, like Microwave Chef and Southern Homes & Gardens. 
        ->END
    =Sofa
        The sofa is well worn. Not by us - we almost never use them anymore. Someone else wore the springs down and ripped the cushion. 
        ->END
    =Sofa2
        Creaky and comfy.
        ->END
    =Armchair
        Mom’s Armchair. She sits here and drinks her coffee after dinner almost every night.
        ->END
    =LivingRug
        Sometimes, when I’m tired, I’ll come in here and stare at this rug to space out. The pattern looks like it starts moving after a while, like watching a popcorn ceiling through fan blades.
        ->END
    
    //LaundryExplore
    =WashDryer
        Our dryer, and our wet-er. 
        ->END
    =LintBucket
        Mom’s lint bucket. She uses this for her plushies. 
        ->END
    
    =Paul1
        It’s a creature with the head of a stuffed bird and the body of a mysteriously decapitated stuffed lion, I think. My mom named it Paul. 
        ->END
    =Paul2
        I think there’s styrofoam in his legs. That’s what keeps him standing upright, and also why he sounds so awful when he moves. 
        ->END
    =PlushieGuts
        I wish there was an easy way to clean plushie guts. This pile alone took me two days and I can still see bits of granola in it. 
        ->END
    =HuskedBear
        Mom keeps saying she’s going to stuff this bear and dress her up like a ballerina. She’s saved a lot of satin for making the dress, but so far the bear is still just an empty husk.
        ->END
    
    //KitchenExplore
    =Fridge
        Cleaning the fridge is pretty easy when it’s half empty, actually. 
        ->END
    =FoodTray
        Cans of green beans, pickled beets, small potatoes, and corn. 
        ->END
    =CoffeePot
        Mom’s coffee pot is pretty old but it’s programmed to start up right before she gets home from work every day.
        ->END
    =Cupboards
        Grandma keeps a whole stack of cake and jello molds in here, but she never bakes anymore. I’m not sure when any of us used them last, since I got in trouble for trying to use it to make a yogurt Santa when I was younger.
        ->END
    =KitchenSink
        Fruit Flies... do they live down there? Is there a world where they’re happy at the bottom of the sink drain?
        ->END
    =Freezer
        I’m supposed to chip away the ice in here so we can get to the steaks Mom got on sale a few months ago. I lost the knife sharpener though and it’s too dangerous to use anything else.
        ->END
    =Plates
        Six nice plates for potatoes with chives, I dropped one last week and then there were five.
        ...Sorry.
        ->END
    =DiningTableCandles
        The lights over the dining table are a lot brighter but my grandma says candlelight is better for reading because it’s less strain on the eyes.
        ->END
    =OpenBooks
        My grandma always reads our family’s old magic books at the table. It’s where she teaches my little brother, too.
        ->END
    =OpenBooksGround
        Why are these on the ground? My grandma would hang me from the coat rack if she saw these here... but I’m also not allowed to touch them anymore.
        ->END
    =OpenBooksGround2
        Maybe my brother was in the middle of a lesson and something happened?
        ->END

    //PantryExplore
    =PastaShelf
        Pasta is nice, when it’s just pasta. Last week I made a bowl of macaroni and I finished half of it before I realized there were moth worms dangling out of the elbow noodles. They were boiled long enough to be safe though, I think, and it’s bad to waste food. 
        ->END
    =CanShelf
        Canned pears, carrots, corn, peas, green beans, kidney beans, navy beans, black beans, refried beans, and beets.
        Mom gets as many of these as she can on sale, since she can’t go to the grocery store often.
        ->END
    =Detergent
        Powdery concentrated detergent. I added too much once and flooded the entire kitchen with suds.
        ->END
    =RecordPlayer
        This record player broke when my brother and I used it to spin dirt figurines around. It still works, but the needle won’t sit right and the turntable is warped.
        ->END
    =Curtains
        The curtains keep out a lot of light, but not any dust. 
        I used to think dust came from sunlight, since I spent a lot of time watching it filter down on sunbeams when I was little. 
        ->END
    =Laundry
        Mom asked me to run the washer today.
        ->END

    //CrawlSpaceExplore
    =VentilationDuct
        These ducts hum and rattle when the A/C or heater turns on.
        Brother and I used to lay rocks on them to make noises whenever the A/C started up, but Grandma noticed right away. 
        ->END