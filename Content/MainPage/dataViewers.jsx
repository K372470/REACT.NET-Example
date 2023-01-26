import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    BarElement,
    Tooltip
} from 'chart.js';
import { Bar } from 'react-chartjs-2';
import React from 'react';

function MainChart({ data }) {
    ChartJS.register(
        CategoryScale,
        LinearScale,
        BarElement,
        Tooltip
    );
    const labels = data.map(item => item.name);
    const chartData = {
        labels,
        datasets: [
            {
                data: data.map(item => item.idCount),
                backgroundColor: 'rgba(232,244,140,0.5)',
                borderColor: 'rgb(240,250,145)',
                borderWidth: 3
            }
        ],
    };

    return (
        <div id='chart' className='Chart' style={{ padding: "10px" }}>
            <Bar data={data} />
        </div >
    );
}
function TableView({ data }) {
    const rows = data.map(item => (
        <tr>
            <td>{item.name}</td>
            <td>{item.idCount}</td>
            <td><a href={`/details?id=${item.id}`}> Read More...</a></td>
        </tr >
    ));
    return (<div id='TableView'>
        <table className="table table-striped text-center table-border border border-2">
            <thead className="thead-dark">
                <tr>
                    <th scope="col">Name</th>
                    <th scope="col">Count</th>
                    <th scope="col">Details</th>
                </tr>
            </thead>
            <tbody>
                {rows}
            </tbody>
        </table>
    </div>
    );
}

export default function Dashboard(props) {
    if (props.data == undefined)
        return <h2 className='noData'>No Data Available</h2>
    else
        return (
            <div id='dataViewer'>
                <MainChart data={props.data} />
                <TableView data={props.data} />
            </div>
        );
}