
import React from 'react';
import './Search.page.css';

const search = (props) => {
    
    let resoults = props.res.map( article => <div key={article.name} onClick={props.clickH}> <img src={article.picture}/> <p>{article.name}</p> </div>);

    return (
    <div className="search-resoults">
        {resoults}
    </div>
);
}


export default search;