<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Movie_Ticket_Management.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
         .modal{
   background-color: rgba(0,0,0, .8);
   width:100%;
   height: 100vh;
   position: absolute;
   top: 0;
   left: 0;
   z-index: 10;
   opacity: 0;
   visibility: hidden;
   transition: all .5s;
  }
         .modal-body{overflow-y:auto;}
  .modal__content{
   width: 30%;
   height: 40%;
   background-color: #fff;
   position: absolute;
   top: 50%;
   left: 50%;
   transform: translate(-50%, -50%);
   padding: 2em;
   border-radius: 1em;
   opacity: 0;
   visibility: hidden;
   transition: all .5s;
  }
  #modals:target{
   opacity: 1;
   visibility: visible;
  }
  #modals:target .modal__content{
   opacity: 1;
   visibility: visible;
  }
  #modal:target{
   opacity: 1;
   visibility: visible;
  }
  #modal:target .modal__content{
   opacity: 1;
   visibility: visible;
  }
  .modal__close{
   color: #363636;
   font-size: 2em;
   position: absolute;
   top: .5em;
   right: 1em;
  }
  .modal__heading{
   color: dodgerblue;
   margin-bottom: 1em;
  }
  .modal__paragraph{
   line-height: 1.5em;
  }
.modal-open{
 display: inline-block;
 color: dodgerblue;
 margin: 2em;
}
        </style>
</head>
<body  style="height: 559px">
    <form id="form1" runat="server">
<div>
    <!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
  Launch demo modal
</button>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <pre><center> Our Journey

20 years ago in South Africa a seed of an idea was planted, a dream was shared. Inception happened. 20 years on, 
            we look back at what we've built. Leave it up to us, and we'd love to do it all over again.
AUG
The Three Musketeers

What happens when 3 long-time friends go holidaying together in South Africa? The seed of a BigTree is planted. A company is planned, 
            from roots to fruits. Soon after the Eureka moment, C.E.O. Shashank V Murthy quits his job at JWT, Co-Founder Shreyas J C takes over Technology, 
            and Co-Founder Rajesh Balpande takes over Finance.
2000
2000 - 01
Gaining ground with Cinema


With the cinema industry on a high and multiplexes and large cinema chains starting to entertain Indian audiences around the country; 
            Bigtree takes over the rights to retail and service New Zealand based ticketing software, Vista in India.
2002
2002 - 2007
Fighting the rough seas

In the midst of the dot com bust that happened in 2002, the company offered technology solutions from the Customer Relationship 
            Management point of view to fight the storm. This business flourished under the leadership of our 3 musketeers.
2007
Mar
The Big Bucks


Network 18 invested in March 2007. In August, the same year an internal contest was held to coin a name for the new company. 
            A developer intern came up with the name MyBang'oreMovies.com and the rest as they say is history.
AUG
Launch of MyBang'oreMovies


Bigtree Entertainment Pvt. Ltd launches India's first ticketing aggregator - MyBang'oreMovies - in August 2007, now one of the 
            biggest ticketing portals in the country.
2010
March 2010
Yeh IPL Hai Boss


MyBang'oreMovies becomes the official ticketing partner for Mumbai Indians, Kings XI Punjab and Delhi Daredevils. Today we have 
            Pune Warriors and Rajasthan Royals too on board this high drama entertainment circus called the IPL.
2011
Mar
Need for Speed


MyBang'oreMovies becomes the exclusive ticketing partner for Formula 1, the Indian Grand Prix. After the grand success of 2011, 
            we are all geared up for 2012's extravaganza.
Mar
The Social Network


MyBang'oreMovies's FaceMyBang'oreMovies page has hit more than 1 Million fans and as of today, our page has over 3.3 Million fans.
Jul
Records are made to be broken


Records are meant to be broken - As it stands today, the highest number of tickets sold in a single month was October 2014 - 
            more than 5 Million - 5,696,685
2012
Jan
And the Award Goes To


MyBang'oreMovies is awarded 'The Hottest Company of the Year-2011-12' and 'The Company to watch out for' at the prestigious 
            CNBC Young Turks Award.
Feb
Mobile Entertainment


MyBang'oreMovies App has around 7.2 Million downloads that includes Windows, Android, iOS and Blackberry.
Aug
Money Matters


Accel Partners invests USD 18 Million Dollars i.e. Rs. 100 crores in MyBang'oreMovies.
2013
Mar
Acquisition


BigTree Entertainment acquires Chennai based online ticketing company Ticket Green.
Dec
Big Ticket


The highest number of tickets sold is for movie Dhoom 3 - 2.2 Million
2014
Jun
Money Matters


SAIF Partners invests USD 25 Million i.e. Rs. 150 crore valuing MyBang'oreMovies at Rs. 1000 crores.
2015
Feb
Acquisition


BigTree Entertainment acquires Bengaluru based Social Media Analytics firm Eventifier.
2016
Mar
Vanakkam Fantain


MyBang'oreMovies acquires a majority stake in Chennai based Fantain Sports Pvt. Ltd.
May
We love awards

MyBang'oreMovies awarded ‘Best Omni-channel Customer Experience Brand’ at the OneDirect Quest Customer Experience (QuestCX) Awards.
Jul
Bigtree grows taller

Raises largest single funding of INR 550 crs led by Stripes Group.
Dec
The all-new Android App


MyBang'oreMovies launches its newly designed Android app packed with some really cool features including Split Costs and Split Tickets.
Dec
Record High!


During the opening weekend of mega blockbuster Dangal, MyBang'oreMovies creates new records; sells over 3 million movie tickets in a 
            single weekend and for shows on Saturday & Sunday, MyBang'oreMovies sells over 1 Million tickets a day!
2017
Jan
Swagata MastiTickets


MyBang'oreMovies acquires Hyderabad based online ticketing platform MastiTickets.
Feb
Hello Townscript

MyBang'oreMovies acquires majority stake in Pune based DIY events ticketing and registration platform Townscript.
Apr
MyBang'oreMovies is the real Baahubali of online ticketing


MyBang'oreMovies alone sells over 15 million tickets for Baahubali 2. The film is also the first on MyBang'oreMovies 
            to generate more than 100 cr business in a single weekend.
Jul
Ed Sheeran tickets- Gone in 48 minutes!

Ed Sheeran Live in Mumbai are sold out on MyBang'oreMovies in a matter of just 48 minutes.
Jul
Welcome Burrp!
Picture

MyBang'oreMovies acquires India’s oldest food tech business Burrp!
Aug
MyBang'oreMovies acquires Nfusion!
Picture

MyBang'oreMovies acqui-hires Nfusion for its audio entertainment offering – Jukebox!</center>
</pre>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
        
     </div>   <!--Login popup-->
   </form>
</body>
</html>
