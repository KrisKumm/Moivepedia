import React, { Component } from 'react';
import './Home.css';

import Toolbar from '../../components/Toolbar/Toolbar';
import { BrowserRouter as Router, Route } from "react-router-dom";
import Search from '../Search/Search.page';
import Film from '../Film/Film.page';
class Home extends Component {

    search = [
        {name: "Forest gump", picture: "https://upload.wikimedia.org/wikipedia/sr/thumb/9/95/Forrest_Gump_DVD.jpg/250px-Forrest_Gump_DVD.jpg"},
        {name: "Avengers", picture: "https://www.nme.com/wp-content/uploads/2019/04/Payoff_1-Sht_Online_v6_Domestic_Sm-1-e1552570783683-696x477.jpg"},
        // {name: "Avengers" picture: ""},
    ]
    movie = {
        name: "Avengers",
        picture: "https://www.nme.com/wp-content/uploads/2019/04/Payoff_1-Sht_Online_v6_Domestic_Sm-1-e1552570783683-696x477.jpg",
        rating: "6.5/10",
        zanra : "comedy/action/thriler",
        cast : [],
        director: "Ljubisa",
        cast: [
            {name: 'milos' , role: 'lelemud' , picture: "https://upload.wikimedia.org/wikipedia/sr/thumb/9/95/Forrest_Gump_DVD.jpg/250px-Forrest_Gump_DVD.jpg"},
            {name: 'milos' , role: 'lelemud' , picture: "https://upload.wikimedia.org/wikipedia/sr/thumb/9/95/Forrest_Gump_DVD.jpg/250px-Forrest_Gump_DVD.jpg"},
    ]
    }
    render() {
        return (
            <div className="Home">
            <Toolbar></Toolbar>
            <Router >
            <Route exact path={"/search"} render={ (props) => <Search res={this.search}/>} />
            <Route exact path={"/film"} render={ (props) => <Film movie={this.movie}/>} />
            <Route exact path={"/series"} render={ (props) => <Film movie={this.movie}/>} />
           
            </Router>
            </div>
        );
    }
}

export default Home;
