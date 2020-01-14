import React, { Component } from 'react';
import './Film.page.css';

import ItemList from '../../components/ItemList/ItemList';
class Film extends Component {

  state = {
    castOpen : false,

  }
  
  CastToggle = () => {
    this.setState((prevState) => {
      return {castOpen: !prevState.castOpen};
    });
  }
  CastClickHandler = (actor) => {
    //idi na stranicu glumca  //verovatno mora ovo da radi app.js
  }
  render() {
  return (
    <div className="film-page">
    <img className="film-picture" src={this.props.movie.picture}/>
      <div className="film-header">
        <div >
            <p>{this.props.movie.name}</p>
            <p className="rating">{this.props.movie.rating}</p>
        </div>
        <p>{this.props.movie.zanra}</p>
      </div>
      <main>
        <p>Treiler</p>
        <iframe width="1189" height="480" src="https://www.youtube.com/embed/eOrNdBpGMv8" frameBorder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowFullScreen></iframe>
        <ItemList show={this.state.castOpen}  list={this.props.movie.cast} name="Cast" avatar={true} expand={this.CastToggle} clickHandler={this.CastClickHandler}/>
      </main>
    </div>
  );
  }
}

export default Film;
