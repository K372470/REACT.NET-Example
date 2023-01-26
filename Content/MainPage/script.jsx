import React, { Component } from 'react';
import DataViewer from './dataViewers.jsx';
import TimeSelector from './timeSelector.jsx';

export default class MainPageApp extends Component {
    state = { data: undefined, isLoading: false }

    handleSubmit(timeRange) {
        this.setState({ isLoading: true })
        let load = new FormData();
        load.append("startTime", timeRange.start);
        load.append("endTime", timeRange.end);
        fetch(this.props["url"], { method: 'POST', body: load })
            .then(x => {
                if (x.status != 405) {
                    x.json()
                        .then(jsonData => this.setState({ data: jsonData }))
                        .finally(() => setTimeout(() => this.setState({ isLoading: false }), 1200));
                }
            })
    }

    render() {
        return (
            <>
                <TimeSelector onSubmit={this.handleSubmit.bind(this)} isLoading={this.state.isLoading} />
                <DataViewer data={this.state.data} />
            </>
        )
    }
}