--the sql string comes FIRST.  the params come next and must be prefixed ':p'.
--  the name the SQL command comes LAST and must be prefixed ':n'
--lines that start with '--' are ignored.

------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
-----CODE TABLE CMDS
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------

update uc_kid 
set first_name = @first_name, 
    is_default_involved = @is_default_involved, 
    is_active = @is_active 
where kid_id = @kid_id;
:pi @kid_id
:pc50 @first_name
:pb @is_default_involved
:pb @is_active
:n _sqcEditCKid

insert into uc_kid 
(first_name, is_default_involved, is_active) 
values 
(@first_name, @is_default_involved, @is_active);
:pc50 @first_name
:pb @is_default_involved
:pb @is_active
:n _sqcAddCKid

update uc_subject 
set subject_desc = @subject_desc, 
    is_active = @is_active 
where subject_id = @subject_id;
:pi @subject_id
:pc100 @subject_desc
:pb @is_active
:n _sqcEditCSubject

insert into uc_subject 
(subject_desc, priority, is_active) 
values 
(@subject_desc, 0, @is_active);
:pc100 @subject_desc
:pb @is_active
:n _sqcAddCSubject

select kid_id, first_name, is_default_involved, is_active 
from uc_kid 
where is_active = 1 
order by first_name;
:n _sqcGetCKidsActive

select kid_id, 
	first_name, 
	is_default_involved, 
	is_active, 
	case is_active 
		when 0 then '(Inactive) ' + first_name 
		else first_name 
	end as first_name_w_active 
from uc_kid 
order by is_active desc, first_name;
:n _sqcGetCKidsAll

select palette_id, palette_name
from uc_palette 
where is_active = 1
order by palette_id;
:n _sqcGetCPalettesActive

select setting_name, datatype, setting_value
from uc_setting
order by setting_name;
:n _sqcGetCSettingsAll

update uc_setting
set setting_value = @setting_value
where setting_name = @setting_name
:pc30 @setting_name
:pc50 @setting_value
:n _sqcEditCSetting

insert into uc_setting
(setting_name, datatype, setting_value)
values
(@setting_name, @datatype, @setting_value)
:pc30 @setting_name
:pc15 @datatype
:pc50 @setting_value
:n _sqcAddCSetting

select display_name, rdlc_name, data_source, datatable_key, parameters 
from uc_report 
where is_active = 1
order by display_name;
:n _sqcGetCReportsActive

select subject_id, subject_desc, priority, is_active 
from uc_subject 
where is_active = 1 
order by priority, subject_desc;
:n _sqcGetCSubjectsActive

select subject_id, 
	subject_desc, 
	priority, 
	is_active, 
	case is_active 
		when 0 then '(Inactive) ' + subject_desc 
		else subject_desc 
	end as subject_desc_w_active 
from uc_subject 
order by is_active desc, priority, subject_desc;
:n _sqcGetCSubjectsAll

------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
-----DATA TABLE CMDS
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------

select distinct e.entry_date,
	ek.kid_id, 
	k.first_name 
from ud_entry as e
inner join ud_entry_to_kid as ek
on e.entry_id = ek.entry_id
inner join uc_kid as k 
on ek.kid_id = k.kid_id 
	and k.is_active = 1 
where e.entry_date >= @start_date 
     and e.entry_date <= @end_date 
order by e.entry_date, k.first_name;
:pd @start_date
:pd @end_date
:n _sqcGetDAttendanceByDateRange

select entry_id, 
	entry_date, 
	case len(entry_title) 
		when 0 then '(no title)' 
		else entry_title 
	end as entry_title, 
	convert(nvarchar(10), entry_date, 101) as entry_date_str,  
	priority 
from ud_entry 
where entry_date >= @start_date 
    and entry_date <= @end_date 
order by entry_date desc, priority, entry_id;
:pd @start_date
:pd @end_date
:n _sqcGetDTitlesByDateRange

select entry_id, 
	case len(entry_title) 
		when 0 then '(no title)' 
		else entry_title 
	end as entry_title, 
	priority 
from ud_entry 
where entry_date = @target_date 
order by priority, entry_id;
:pd @target_date
:n _sqcGetDTitlesByTargetDate

select entry_id, entry_date, is_no_publish, 
    entry_title, minutes_spent, entry_text, minutes_spent, priority, 
    insert_datetime, update_datetime 
from ud_entry 
where entry_id = @entry_id;
:pi @entry_id
:n _sqcGetDEntryByID

--putting entry_date 2nd allows use of GetScalar().
select sum(minutes_spent) as total_minutes_spent, entry_date
from ud_entry
where entry_date = @entry_date
group by entry_date;
:pd @entry_date
:n _sqcGetDEntriesMinutesByDate

--putting entry_date 2nd allows use of GetScalar().
select count(entry_id) as total_entry_count, entry_date
from ud_entry
where entry_date = @entry_date
group by entry_date;
:pd @entry_date
:n _sqcGetDEntriesCountByDate

select sum(minutes_spent) as total_minutes_spent
from ud_entry
:n _sqcGetDEntriesMinutesAll

select count(entry_id) as total_entry_count
from ud_entry
:n _sqcGetDEntriesCountAll

select distinct entry_title
from ud_entry 
where entry_date >= dateadd(d, -91, getdate())
order by entry_title
:n _sqcGetDEntryTitlesDistinct90Days

select entry_id, kid_id 
from ud_entry_to_kid 
where entry_id = @entry_id;
:pi @entry_id
:n _sqcGetDKidsByID

select entry_id, subject_id 
from ud_entry_to_subject 
where entry_id = @entry_id;
:pi @entry_id
:n _sqcGetDSubjectsByID

insert into ud_entry 
(entry_date, is_no_publish, entry_title, minutes_spent, entry_text, 
   priority, insert_datetime, update_datetime) 
values 
(@entry_date, @is_no_publish, @entry_title, @minutes_spent, @entry_text, 
   @priority, getdate(), getdate());
:pd @entry_date
:pb @is_no_publish
:pc100 @entry_title
:pi @minutes_spent
:pt @entry_text
:pi @priority
:n _sqcAddDEntry

select @@identity as new_id_value;
:n _sqcGetDNewIDValue

update ud_entry 
set is_no_publish = @is_no_publish, 
	entry_title = @entry_title, 
	minutes_spent = @minutes_spent, 
	entry_text = @entry_text, 
	update_datetime = getdate() 
where entry_id = @entry_id;
:pi @entry_id
:pb @is_no_publish
:pc100 @entry_title
:pi @minutes_spent
:pt @entry_text
:n _sqcEditDEntry

update ud_entry 
set entry_date = @entry_date, 
	update_datetime = getdate() 
where entry_id = @entry_id;
:pd @entry_date
:pi @entry_id
:n _sqcEditDEntryDate

delete from ud_entry_to_subject 
where entry_id = @entry_id;
:pi @entry_id
:n _sqcDeleteDSubjectsByEntryID

delete from ud_entry_to_kid 
where entry_id = @entry_id;
:pi @entry_id
:n _sqcDeleteDKidsByEntryID

delete from ud_entry 
where entry_id = @entry_id;
:pi @entry_id
:n _sqcDeleteDEntryByEntryID

insert into ud_entry_to_subject 
(entry_id, subject_id) 
values 
(@entry_id, @subject_id);
:pi @entry_id
:pi @subject_id
:n _sqcAddDEntrySubject

insert into ud_entry_to_kid 
(entry_id, kid_id) 
values 
(@entry_id, @kid_id);
:pi @entry_id
:pi @kid_id
:n _sqcAddDEntryKid

------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
-----REPORTING CMDS
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------

select convert(nvarchar(11), uck.kid_id) as String1, 
	 uck.first_name as String2,
	 datediff(d, @start_date, @end_date) + 1 as Int1,
	 count(att.entry_date) as Int2
from uc_kid as uck 
inner join 
	(select distinct dek.kid_id, de.entry_date
	from ud_entry as de
	inner join ud_entry_to_kid as dek
	on de.entry_id = dek.entry_id
	where de.entry_date >= @start_date
		and de.entry_date <= @end_date
		and (dek.kid_id = @kid_id or @kid_id = -1) 
	) as att
on att.kid_id = uck.kid_id
group by uck.kid_id, uck.first_name
order by uck.first_name
:pd @start_date
:pd @end_date
:pi @kid_id
:n _sqcGetRAttendance

select e.entry_id as Int1, 
	convert(nvarchar(10), e.entry_date, 101) as String1, 
	e.entry_title as String2, 
	e.entry_text as String3, 
	e.minutes_spent as Int2, 
	e.entry_date as DateTime1 
from ud_entry as e 
where e.entry_date >= @start_date 
     and e.entry_date <= @end_date 
     and 
		(exists (select * from ud_entry_to_kid as iek where e.entry_id = iek.entry_id and iek.kid_id = @kid_id)
		or
		@kid_id = -1)
     and 
		(exists (select * from ud_entry_to_subject as ies where e.entry_id = ies.entry_id and ies.subject_id = @subject_id)
		or 
		@subject_id = -1)
order by e.entry_date, e.priority, e.entry_id;
:pd @start_date
:pd @end_date
:pi @kid_id
:pi @subject_id
:n _sqcGetREntriesByDate

select convert(nvarchar(11), ek.kid_id) as String1, 
	uck.first_name as String2, 
	convert(nvarchar(11), es.subject_id) as String3, 
	ucs.subject_desc as String4, 
	sum(e.minutes_spent) as Int1,
	0 as Int2
from ud_entry as e 
inner join ud_entry_to_subject as es 
on e.entry_id = es.entry_id 
inner join uc_subject as ucs 
on es.subject_id = ucs.subject_id 
inner join ud_entry_to_kid as ek 
on e.entry_id = ek.entry_id 
inner join uc_kid as uck 
on ek.kid_id = uck.kid_id 
where e.minutes_spent is not null 
	and e.entry_date >= @start_date 
	and e.entry_date <= @end_date 
	and (ek.kid_id = @kid_id or @kid_id = -1) 
	and (es.subject_id = @subject_id or @subject_id = -1) 
group by ek.kid_id, uck.first_name, es.subject_id, ucs.subject_desc 
union
select convert(nvarchar(11), ek.kid_id) as String1, 
	uck.first_name as String2, 
	'7654321' as String3, 
	'Total Time Spent:' as String4, 
	sum(e.minutes_spent) as Int1,
	1 as Int2
from ud_entry as e 
inner join ud_entry_to_kid as ek 
on e.entry_id = ek.entry_id 
inner join uc_kid as uck 
on ek.kid_id = uck.kid_id 
where e.minutes_spent is not null 
	and e.entry_date >= @start_date 
	and e.entry_date <= @end_date 
	and (ek.kid_id = @kid_id or @kid_id = -1) 
	and 
		(exists (select * from ud_entry_to_subject as ies where e.entry_id = ies.entry_id and ies.subject_id = @subject_id) 
		or 
		@subject_id = -1)
group by ek.kid_id, uck.first_name 
order by uck.first_name, String1, Int2, ucs.subject_desc;
:pd @start_date
:pd @end_date
:pi @kid_id
:pi @subject_id
:n _sqcGetRTimeSpentPerSubjectByKid

select convert(nvarchar(11), ek.kid_id) as String1, 
	 uck.first_name as String2, 
	 'obsolete' as String3, 
	 convert(nvarchar(10), e.entry_date, 120) as String4,
	 datename(dw, e.entry_date) as String5,
	 sum(e.minutes_spent) as Int1,
	 0 as Int2,
	 e.entry_date as DateTime1
from ud_entry as e 
inner join ud_entry_to_kid as ek 
on e.entry_id = ek.entry_id 
inner join uc_kid as uck 
on ek.kid_id = uck.kid_id 
where e.minutes_spent is not null 
     and e.entry_date >= @start_date 
     and e.entry_date <= @end_date 
     and (ek.kid_id = @kid_id or @kid_id = -1) 
group by ek.kid_id, uck.first_name, e.entry_date
union
select convert(nvarchar(11), ek.kid_id) as String1, 
	 uck.first_name as String2, 
	 'obsolete' as String3, 
	 '1900-01-01' as String4,
	 'No Day Name' as String5,
	 sum(e.minutes_spent) as Int1,
	 1 as Int2,
	 '1900-01-01' as DateTime1
from ud_entry as e 
inner join ud_entry_to_kid as ek 
on e.entry_id = ek.entry_id 
inner join uc_kid as uck 
on ek.kid_id = uck.kid_id 
where e.minutes_spent is not null 
     and e.entry_date >= @start_date 
     and e.entry_date <= @end_date 
     and (ek.kid_id = @kid_id or @kid_id = -1) 
group by ek.kid_id, uck.first_name
order by String1, Int2, String4 desc;
:pd @start_date
:pd @end_date
:pi @kid_id
:n _sqcGetRTimeSpentPerDateByKid
