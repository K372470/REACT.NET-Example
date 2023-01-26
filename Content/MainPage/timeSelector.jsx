import React, { useState, useEffect } from 'react';

export default function TimeSelector(props) {
    const [startTime, setStart] = useState(new Date('2005'));
    const [endTime, setEnd] = useState(new Date());
    const [isValid, setValid] = useState(false);
    useEffect(() => setValid(startTime <= endTime), [startTime, endTime]);

    function handleSubmit(e) {
        e.preventDefault();
        if (isValid) {
            props.onSubmit({ start: startTime, end: endTime });
        }
    }
    const getFormControlClassName = () => 'form-control ' + (isValid ? 'is-valid' : 'is-invalid');
    const getLoadingButtonStyle = () => ({ display: props.isLoading ? 'inline-block' : 'none' });
    const getDateInputChangeHandler = stateSetter => e => stateSetter(new Date(e.target.value));
    return (
        <div id='TimeSelector' className='timeSelector text-center'>
            <form onSubmit={handleSubmit} className='needs-validation row h-75 g-3'>
                <label className='form-label'>
                    Start Time<input type='date' id='startTime' value={startTime.toISOString().substring(0, 10)} min='2005-01-01' className={getFormControlClassName()} onChange={getDateInputChangeHandler(setStart)} required />
                    <span className='invalid-feedback'>StartTime Must be above EndTime</span>
                </label>
                <label className='form-label'>
                    End Time<input type='date' id='endTime' min='2005-01-02' value={endTime.toISOString().substring(0, 10)} className={getFormControlClassName()} onChange={getDateInputChangeHandler(setEnd)} required />
                </label>
                <button type='submit' className='btn btn-outline-primary'>Use Selected Data<span style={getLoadingButtonStyle()} className="spinner-border spinner-border-sm buttonLoader"></span></button>
            </form>
        </div>
    );
}