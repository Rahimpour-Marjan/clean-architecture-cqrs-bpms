import styled from 'styled-components';
import { Button } from '../../components';
import { PAGE_SIZE } from '../../constants/pagination';
import { usePosts } from '../../hooks/usePosts';

const PaginationStyled = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 0.5rem;
  font-size: 18px;
  font-weight: 700;
  line-height: 21px;

  button {
    background-color: transparent;
    border: none;
    padding: 0.25rem 0.5rem;
    color: var(--grey-500);

    &.active {
      color: var(--primary-800);
      border: 1px solid var(--primary-800);
      border-radius: var(--border-radius-1);
    }
  }
`;

export const Pagination = () => {
  const { posts } = usePosts();

  // const totalRecord = posts.length;
  const totalRecord = 91;
  const numPages = Math.ceil(totalRecord / PAGE_SIZE);

  return (
    <PaginationStyled>
      <Button>&lt;</Button>
      <Button className='active'>1</Button>
      {numPages > 2 && (
        <>
          <Button>2</Button>
          <p>...</p>
          <Button>{numPages}</Button>
        </>
      )}
      <Button>&gt;</Button>
    </PaginationStyled>
  );
};
